namespace The_Wall.Models
{
    public class CommentsMessagesViewModel{
        public List<Message> Messages {get;set;} = new List<Message>();
        public Message Newmessage{get;set;} = new Message();
        public Comment NewComment{get;set;} = new Comment();
    }
}