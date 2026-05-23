using Microsoft.AspNetCore.Http;
using VotingContract;

namespace Voting.Data;

public sealed partial class PollService
{
    private readonly IGrainFactory _grainFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IUserAgentGrain _userAgentGrain;

    public PollService(IGrainFactory grainFactory, IHttpContextAccessor httpContextAccessor)
    {
        _grainFactory = grainFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    private IUserAgentGrain GetUserAgentGrain()
    {
        if (_userAgentGrain is null)
        {
            var clientIp = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            _userAgentGrain = _grainFactory.GetGrain<IUserAgentGrain>(clientIp);
        }
        return _userAgentGrain;
    }

    public Task<string> CreatePollAsync(string question, List<string> options) =>
        GetUserAgentGrain().CreatePoll(new PollState
        {
            Question = question,
            Options = options.Select(o => (o, 0)).ToList()
        });

    public Task<(PollState Results, bool Voted)> GetPollResultsAsync(string pollId) =>
        GetUserAgentGrain().GetPollResults(pollId);

    public Task<PollState> AddVoteAsync(string pollId, int optionId) =>
        GetUserAgentGrain().AddVote(pollId, optionId);

    public async ValueTask<IAsyncDisposable> WatchPoll(string pollId, IPollWatcher watcherObject)
    {
        var pollGrain = _grainFactory.GetGrain<IPollGrain>(pollId);
        var watcherReference = _grainFactory.CreateObjectReference<IPollWatcher>(watcherObject);
        var result = new PollWatcherSubscription(watcherObject, pollGrain, watcherReference);

        await ValueTask.CompletedTask;

        return result;
    }
}