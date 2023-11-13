namespace NewRepo.DTO
{
    public class CreateUserDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public long roleId {get; set; }
    }
}
