using SQLite;


namespace FragmentNoteApp
{
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}