
namespace System.Linq.Dynamic.Tests.Helpers.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public DateTime PostDate { get; set; }

        public int NumberOfReads { get; set; }

        //public override int GetHashCode()
        //{
        //    return PostId.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Post;

        //    if (other == null) return false;

        //    return PostId.Equals(other.PostId);
        //}
    }
}