namespace DataModel
{
    using System.Collections.Generic;
    
    public partial class HashTag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HashTag()
        {
            this.HashTagTweetMaps = new HashSet<HashTagTweetMap>();
        }
    
        public int HashTagId { get; set; }
        public string HashTagContent { get; set; }
        public int Count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HashTagTweetMap> HashTagTweetMaps { get; set; }
    }
}
