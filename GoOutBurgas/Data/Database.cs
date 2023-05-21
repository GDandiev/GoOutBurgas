using GoOutBurgas.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOutBurgas.Data
{
    class Database
    {
        SQLiteAsyncConnection MainDatabase;

        public Database()
        {

        }

        async Task Init()
        {
            if (MainDatabase is not null)
                return;

            MainDatabase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await MainDatabase.CreateTableAsync<User>();
            var userToInsert = new User();
        }

        public async Task<List<User>> GetItemsAsync()
        {
            await Init();
            return await MainDatabase.Table<User>().ToListAsync();
        }

        public async Task<List<User>> GetUsersNotDoneAsync()
        {
            await Init();
            return await MainDatabase.Table<User>().Where(t => t.Admin).ToListAsync();

        }

        public async Task<bool> LoginUser(string acc, string pass)
        {
            MainDatabase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            var user = await MainDatabase.Table<User>().Where(x => x.Email == acc).FirstOrDefaultAsync();

            return true;
        }

        public async Task<User> LoginCheck(string loginCheck, string passCheck)
        {
            await Init();

            User searchDb = await MainDatabase.Table<User>().Where(a => a.Email == loginCheck && a.Password == passCheck).FirstOrDefaultAsync();
            return searchDb;
        }

        public async Task<User> Register(string email, string pass)
        {
            await Init();

            User userToInsert = new User();
            userToInsert.Email = email;
            userToInsert.Password = pass;
            await MainDatabase.InsertAsync(userToInsert);

            User searchDb = await MainDatabase.Table<User>().FirstOrDefaultAsync();
            return searchDb;
        }

        public async Task<User> GetItemAsync(int id)
        {
            await Init();
            return await MainDatabase.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(User users)
        {
            await Init();
            if (users.ID != 0)
            {
                return await MainDatabase.UpdateAsync(users);
            }
            else
            {
                return await MainDatabase.InsertAsync(users);
            }
        }

        public async Task<int> DeleteUserAsync(User users)
        {
            await Init();
            return await MainDatabase.DeleteAsync(users);
        }

        public async Task<User> UpdateUser(string email, string pass)
        {
            await Init();

            User searchDb = await MainDatabase.Table<User>().Where(i => i.Email == email).FirstOrDefaultAsync();

            if (searchDb != null)
            {
                searchDb.Email = email;
                searchDb.Password = pass;

                await MainDatabase.UpdateAsync(searchDb);
            }

            return searchDb;
        }
    }
}
