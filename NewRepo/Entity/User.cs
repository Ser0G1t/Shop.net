namespace NewRepo.Entity
{
    public class User
    {
        public long userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zipCode {  get; set; }
        public Role role { get; set; }
        public long roleId { get; set; }
        public DateTime createdDate { get; set; }
        public User()
        {
            createdDate = DateTime.Now;
        }

    }
}
