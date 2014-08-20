using System;

namespace Domain
{
    public class Review
    {
        public virtual Guid ID { get; set; }

        public virtual string Name{get;set;}

        public virtual string Email{get;set;}
        
        public virtual int Rating { get; set; }
        
        public virtual string Content { get; set; }
        
        public virtual Article Article { get; set; }

        public virtual string Reply { get; set; }

        public virtual DateTime ReviewDate { get; set; }

        public virtual DateTime ReplyDate { get; set; }

        public virtual bool IsEnabled { get; set; }
    }

}
