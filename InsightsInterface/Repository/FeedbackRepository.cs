using MongoDB.Driver;

public interface IFeedbackRepository
{
    Task<List<Feedback>> GetAllAsync();
    Task<Feedback?> GetByIdAsync(string id);
    Task CreateAsync(Feedback feedback);
    Task UpdateAsync(string id, Feedback feedback);
    Task DeleteAsync(string id);
}

public class FeedbackRepository : IFeedbackRepository
{
    private readonly IMongoCollection<Feedback> _feedbacks;

    public FeedbackRepository(IMongoDatabase database)
    {
        _feedbacks = database.GetCollection<Feedback>("feedback");
    }

    public async Task<List<Feedback>> GetAllAsync()
    {
        return await _feedbacks.Find(_ => true).ToListAsync();
    }


    public async Task<Feedback?> GetByIdAsync(string id)
    {
        var objectId = new string(id);
        return await _feedbacks.Find(f => f.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Feedback feedback)
    {
        await _feedbacks.InsertOneAsync(feedback);
    }

    public async Task UpdateAsync(string id, Feedback feedback)
    {
        var objectId = new string(id);
        feedback.Id = objectId;
        await _feedbacks.ReplaceOneAsync(f => f.Id == objectId, feedback);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = new string(id);
        await _feedbacks.DeleteOneAsync(f => f.Id == objectId);
    }
}
