//No Edits needed ,, just inject in WrongbuttonClick
using Microsoft.Data.SqlClient;
using guessing_app.Data;

namespace guessing_app.Services
{
    public class DatabaseService
    {
        private readonly DbContext dbContext; // bakhod obj to iject connection
         public DatabaseService(DbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


    //method to get id of inserted raw
    private async Task<int> getID()
        {
            int rawId = -1;
            using(SqlConnection conn = dbContext.sqlConn())
            {
                await conn.OpenAsync();
                string query = "INSERT INTO prediction (dateTime) OUTPUT INSERTED.pred_id VALUES (@dateTime)";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("dateTime", DateTime.Now);
                    object? res = await cmd.ExecuteScalarAsync();
                    if(res != null)
                    {
                        rawId = (int)res;
                    }
                }
            }
            return rawId;
        }
        //asynchronus method for not app freezing + task datatype 
        public async Task insertWrongPred(int id, string imagePath, string wrongAnswer, string correctAnswer)
        {
            
            try
            {

                string query = @"INSERT INTO pred_details (pred_id, image_path, wrong_answer, correct_answer) VALUES (@pred_id, @image_path, @wrong_answer, @correct_answer)";
                using (SqlConnection conn = dbContext.sqlConn())
                {
                    await conn.OpenAsync();
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@pred_id", id);
                        comm.Parameters.AddWithValue("@image_path", imagePath);
                        comm.Parameters.AddWithValue("@wrong_answer", wrongAnswer);
                        comm.Parameters.AddWithValue("@correct_answer", correctAnswer);
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

    }
}

