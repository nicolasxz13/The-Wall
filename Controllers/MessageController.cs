using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Wall.Data;
using The_Wall.Filters;
using The_Wall.Models;

namespace The_Wall.Controllers
{
    public class MessageController : Controller
    {
        private readonly LoginContext _context;

        public MessageController(LoginContext loginContext)
        {
            _context = loginContext;
        }

        [SessionCheck]
        [HttpGet("messages")]
        public IActionResult Index()
        {
            List<Message> messages = _context.Messages
                .Include(a => a.UserMessage)
                .Include(a => a.Comments)
                .OrderByDescending(a => a.CreatedAt)
                .ToList();
            CommentsMessagesViewModel commentsMessagesViewModel = new CommentsMessagesViewModel();
            commentsMessagesViewModel.Messages = messages;
            return View(commentsMessagesViewModel);
        }

        [SessionCheck]
        [HttpPost("messages/create")]
        public IActionResult Create(Message message)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid && userid != null)
            {
                User? user = _context.Users.Find(userid);
                if (user != null)
                {
                    message.UserMessage = user;
                    message.CreatedAt = DateTime.Now;
                    message.UpdatedAt = DateTime.Now;
                    _context.Add(message);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                List<Message> modelmessage = _context.Messages
                    .Include(a => a.UserMessage)
                    .Include(a => a.Comments)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
                CommentsMessagesViewModel commentsMessagesViewModel =
                    new CommentsMessagesViewModel();
                commentsMessagesViewModel.Messages = modelmessage;
                commentsMessagesViewModel.Newmessage = message;

                return View("Index", commentsMessagesViewModel);
            }
        }

        [SessionCheck]
        [HttpPost("messages/{id}/destroy")]
        public IActionResult Delete(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (userid != null)
            {
                Message? message = _context.Messages.FirstOrDefault(
                    a => a.MessageId == id && a.UserMessage.Id == userid
                );

                if (message != null)
                {
                    List<Comment>? comments = _context.Comments
                        .Where(a => a.Message.MessageId == message.MessageId)
                        .ToList();
                    if (comments.Any())
                    {
                        _context.Comments.RemoveRange(comments);
                    }
                    _context.Messages.Remove(message);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [SessionCheck]
        [HttpPost("message/{id}/comment/create")]
        public IActionResult CreateComment(int id, Comment comment)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid && userid != null)
            {
                User? user = _context.Users.Find(userid);
                Message? message = _context.Messages.Find(id);
                if (user != null && message != null)
                {
                    comment.UserComment = user;
                    comment.Message = message;
                    comment.CreatedAt = DateTime.Now;
                    comment.UpdatedAt = DateTime.Now;
                    _context.Add(comment);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                List<Message> modelmessage = _context.Messages
                    .Include(a => a.UserMessage)
                    .Include(a => a.Comments)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
                CommentsMessagesViewModel commentsMessagesViewModel =
                    new CommentsMessagesViewModel();
                commentsMessagesViewModel.Messages = modelmessage;
                commentsMessagesViewModel.NewComment = comment;

                return View("Index", commentsMessagesViewModel);
            }
        }

        [SessionCheck]
        [HttpPost("message/{id}/comment/{commentid}")]
        public IActionResult DeleteComment(int id, int commentid)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (userid != null)
            {
                Comment? comment = _context.Comments.FirstOrDefault(
                    a =>
                        a.CommentId == commentid
                        && a.UserComment.Id == userid
                        && a.Message.MessageId == id
                );
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
