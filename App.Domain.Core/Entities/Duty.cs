namespace App.Domain.Core.Entities
{
    public class Duty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "انتخاب عنوان وظیفه اجباری است")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "لطفاً وضعیت وظیفه را مشخص کنید.")]
        public bool IsCompleted { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
