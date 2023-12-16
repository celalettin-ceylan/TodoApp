namespace NetApp.Models;
public class TodoItem{
    public TodoItem(String name)
    {
        Name = name;
        CreatedAt = DateTime.Now;
        IsDone = false;
    }

    public TodoItem(String name, DateTime create_at, bool is_done)
    {
        Name = name;
        CreatedAt = create_at;
        IsDone = is_done;
    }
    public int Id { get; set; }
    public String Name {get; set;}
    public DateTime CreatedAt { get; set; }
    public bool IsDone { get; set; }
}