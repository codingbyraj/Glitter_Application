namespace HashTagAccess
{
    using System.Linq;
    using DataModel;
    using System;

    public class HashTagDb
    {
        private GlitterDBEntities db;
        public HashTagDb()
        {
            db = new GlitterDBEntities();
        }

        public int GetHashTagId(string hashTag)
        {
            int hashTagId = 0;
            try
            {
                var hashTagObj = db.HashTags.Where(x => x.HashTagContent == hashTag).FirstOrDefault();
                if (hashTagObj != null)
                {
                    hashTagId = hashTagObj.HashTagId;
                }
            }
            catch (Exception) {
                Console.WriteLine("Error in database connectivity");
            }
            return hashTagId;
        }

        public int UpdateHashTag(string hashTag)
        {
            int hashTagId = 0;
            try {
                var hashTagObj = db.HashTags.Where(x => x.HashTagContent == hashTag).FirstOrDefault();
                if (hashTagObj != null)
                {
                    if (hashTagObj.Count > 1)
                    {
                        hashTagObj.Count = hashTagObj.Count - 1;
                        hashTagId = hashTagObj.HashTagId;
                        Save();
                    }
                    else
                    {
                        db.HashTags.Remove(hashTagObj);
                        Save();
                        hashTagId = hashTagObj.HashTagId;
                    }
                }
            }
            catch (Exception) {
                Console.WriteLine("Error in database connection");
            }
            return hashTagId;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
