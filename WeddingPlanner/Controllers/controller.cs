      [Route(]"dashboard")]
        public IActionResult dashboard()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Posts = _context.Messages.Include(p => p.creator).Include(u => u.likes).OrderByDescending(mg => mg.likes.Count);
            ViewBag.CurrentUser = _context.Users.SingleOrDefault(cu => cu.Id == HttpContext.Session.GetInt32("Id"));
            return View();
        }

        [Route("createPost")]
        public IActionResult CreatePost(RegisterViewMessage message)
        {
            if(ModelState.IsValid)
            {
                Message newMessage = new Message
                {
                    content = message.content,
                    userId = HttpContext.Session.GetInt32("Id")
                };
                _context.Add(newMessage);
                _context.SaveChanges();
                return RedirectToAction("dashboard");
            }
            return View();
        }
        [Route("like/{messageId}")]
        public IActionResult Like(int messageId)
        {
            Post userposts = _context.Posts.SingleOrDefault(wp => wp.MessageId == messageId && wp.UserId == HttpContext.Session.GetInt32("Id"));
            if(userposts != null)
            {
                return RedirectToAction("Dashboard");
            }
            Post LikedPost = new Post
            {
                MessageId = messageId,
                UserId = (int)HttpContext.Session.GetInt32("Id")
            };
            _context.Posts.Add(LikedPost);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // IF the planId is equal to the planID in the ManyToMany table & the userId is also equal to your session, then this will pull the plan with both values.
        [Route("dislike/{messageId}")]
        public IActionResult UnAttend(int messageId)
        {
            Post LikedPost = _context.Posts.SingleOrDefault(at => at.MessageId == messageId && at.UserId == HttpContext.Session.GetInt32("Id"));
            _context.Posts.Remove(LikedPost);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Route("delete/{messageId}")]
        public IActionResult Delete(int? messageId)
        {
            List<Message> singleMessage = _context.Messages.Where(m => m.Id == messageId).Include(l => l.likes).ToList();
            foreach(var deletepost in singleMessage[0].likes)
            {
                _context.Posts.Remove(deletepost);
                if(singleMessage[0].likes.Count == 0)
                {
                    break;
                }
            }
            _context.Messages.Remove(singleMessage[0]);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Route("message/{messageId}")]
        public IActionResult SingleMessage(int messageId)
        {
            ViewBag.Message = _context.Messages.Where(p => p.Id == messageId).Include(up => up.likes).ThenInclude(u => u.user).Include(h => h.creator);
            var test = _context.Messages.Where(p => p.Id == messageId).Include(up => up.likes).ThenInclude(u => u.user).Include(h => h.creator);
            return View();
        }
        [Route("user/{userid}")]
        public IActionResult SingleUser(int userid)
        {
            List<User> singleuser = _context.Users.Where(person => person.Id == userid).Include(u => u.posts).Include(pt => pt.posts).ToList();
            List<Message> userposts = _context.Messages.Where(ids => ids.userId == userid).ToList();
            ViewBag.User = singleuser;
            ViewBag.Message = userposts;
            return View();
        }

    }