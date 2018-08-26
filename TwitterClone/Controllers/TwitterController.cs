using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class TwitterController : Controller
    {
        private PersonManager personManager = new PersonManager();

        // GET: Twitter
        public ActionResult Tweet()
        {
            if (Session["UserName"] != null)
            {
                string userId = Session["UserName"].ToString();
                TweetViewModel tweetViewModel = new TweetViewModel();
                tweetViewModel.Tweets = new Collection<TweetModel>();
                Collection<Tweet> tweets = personManager.GetFollowingTweets(userId);
                tweets.ToList().ForEach(x =>
                tweetViewModel.Tweets.Add(new TweetModel()
                {
                    TweetId = x.Tweet_Id,
                    UserId = x.User_Id,
                    Message = x.Message,
                    CreatedDate = x.Created
                }));
                tweetViewModel.IsTweetPage = true;
                return View(tweetViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddTweet(string message)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Tweet tweet = new Tweet
                    {
                        User_Id = Session["UserName"].ToString(),
                        Message = message,
                        Created = DateTime.Now
                    };

                    personManager.SaveTweet(tweet);

                }
                else
                {
                    Session["LoginModel"] = null;
                    Session["UserName"] = null;
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception)
            {
                AddErrors("Problem with our end. Please try again later..");
            }
            return RedirectToAction("Tweet", "Twitter");
        }

        private void AddErrors(string error)
        {
            ModelState.AddModelError("", error);
        }
    }
}