using System.Collections.Generic;

namespace System.Linq.Dynamic.Tests.Helpers.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        //public override int GetHashCode()
        //{
        //    return BlogId.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Blog;

        //    if (other == null) return false;

        //    return BlogId.Equals(other.BlogId);
        //}
    }
}
