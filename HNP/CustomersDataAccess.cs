using SQLite;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HNP
{
    public class CustomersDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Users> Users { get; set; }
        public ObservableCollection<Dates> Dates { get; set; }

        public CustomersDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Users>();
            this.Users = new ObservableCollection<Users>(database.Table<Users>());
            database.CreateTable<Dates>();
            this.Dates = new ObservableCollection<Dates>(database.Table<Dates>());
        }
        public Users GetUser(string login)
        {
            lock (collisionLock)
            {
                return database.Table<Users>().FirstOrDefault(user => user.Login == login);
            }
        }
        public Users GetEmail(string email)
        {
            lock (collisionLock)
            {
                return database.Table<Users>().FirstOrDefault(user => user.Email == email);
            }
        }
        public int SaveUser(Users user)
        {
            lock (collisionLock)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    database.Insert(user);
                    return user.Id;
                }
            }
        }
        public int DeleteUser(Users user)
        {
            var id = user.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Users>(id);
                }
            }
            this.Users.Remove(user);
            return id;
        }
        public Dates GetDate(string Date)
        {
            lock (collisionLock)
            {
                return database.Table<Dates>().FirstOrDefault(date => date.Date == Date);
            }
        }
        public int SaveDate(Dates dates)
        {
            lock (collisionLock)
            {
                if(dates.Id_date != 0)
                {
                    database.Update(dates);
                    return dates.Id_date;
                }
                else
                {
                    database.Insert(dates);
                    return dates.Id_date;
                }
            }
        }
    }
}