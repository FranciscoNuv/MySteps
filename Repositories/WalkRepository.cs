using SQLite;
using MySteps.Models;

namespace MySteps.Repositories;
public class WalkRepository
{
    string _dbPath;
    private SQLiteAsyncConnection conn;

    public string StatusMessage { get; set; }

    private async Task Init()
    {
        // TODO: Add code to initialize the repository         
        if (conn != null)
            return;
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Walk>();
    }

    public WalkRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public async Task AddNewWalk(Walk w)
    {            
        int result = 0;
        try
        {
            await Init();
            result = await conn.InsertAsync(w);
            StatusMessage = string.Format("{0} record(s) added (Distance: {1})", result, w.DistanceKm);
        }
        catch (Exception ex)
        {
            result = 0;
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", w.DistanceKm, ex.Message);
        }
    }

    public async Task UpdateWalk(Walk w)
    {
        int result = 0;
        try
        {
            await Init();
            result = await conn.UpdateAsync(w);
            StatusMessage = string.Format("{0} record(s) updated (Id: {1})", result, w.Id);
        }
        catch (Exception ex)
        {
            result = 0;
            StatusMessage = string.Format("Failed to update {0}. Error: {1}", w.Id, ex.Message);
        }
    }

    public async Task DeleteWalk(int walkID)
    {
        int result = 0;
        try
        {
            await Init();
            result = await conn.DeleteAsync<Walk>(walkID);
            StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, walkID);
        }
        catch (Exception ex)
        {
            result = 0;
            StatusMessage = string.Format("Failed to delete {0}. Error: {1}", walkID, ex.Message);
        }
    }

    public async Task<Walk?> GetWalk(int walkID)
    {
        try
        {
            await Init();
            return await conn.Table<Walk>().Where(x=>x.Id==walkID).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
        return new Walk();
        
    }
    public async Task<List<Walk>> GetAllWalks()
    {
        try
        {
            await Init();
            return await conn.Table<Walk>().OrderByDescending(x=>x.DateUtc).ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
        return new List<Walk>();
    }
}