using System;
using api_desis.DesisEfCore;

namespace api_desis.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save the entry
        /// </summary>
        /// <param name="entryModel"></param>
        public void SaveEntry(EntryModel entryModel)
        {
            DesisEntry dbTable = new DesisEntry();
            if (entryModel.id > 0)
            {
                dbTable = _context.desisEntries.Where(g => g.id.Equals(entryModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.name = entryModel.name;
                    dbTable.category = entryModel.category;
                }
            }
            else
            {
                dbTable.name = entryModel.name;
                dbTable.category = entryModel.category;
                _context.desisEntries.Add(dbTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// It gets all the entries
        /// </summary>
        /// <returns> List Of Entries </returns>
        public List<EntryModel> GetEntries()
        {
            List<EntryModel> response = new List<EntryModel>();
            var dataList = _context.desisEntries.ToList();

            dataList.ForEach(row => response.Add(
                new EntryModel()
                {
                id = row.id,
                category = row.category,
                name = row.name,
                DesisComments = this.GetComments(row.id),
                DesisRatings = this.GetRating(row.id)
            }));
            return response;
        }

        /// <summary>
        /// DELETE the entry
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEntry(int id)
        {
            var entry = _context.desisEntries.Where(h => h.id.Equals(id)).FirstOrDefault();
            if (entry != null)
            {
                _context.desisEntries.Remove(entry);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Save the comment
        /// </summary>
        /// <param name="commentModel"></param>
        public void SaveComment(CommentModel commentModel)
        {
            DesisComment dbTable = new DesisComment();
            if (commentModel.commentId > 0)
            {
                dbTable = _context.desisComments.Where(d => d.commentId.Equals(commentModel.commentId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.comment = commentModel.comment;
                    dbTable.dateTime = commentModel.dateTime;
                }
            }
            else
            {
                dbTable.comment = commentModel.comment;
                dbTable.dateTime = commentModel.dateTime;
                dbTable.DesisEntry = _context.desisEntries.Where(f => f.id.Equals(commentModel.DesisEntryId)).FirstOrDefault();
                dbTable.DesisUser = _context.desisUsers.Where(f => f.id.Equals(commentModel.DesisUserId)).FirstOrDefault();
                _context.desisComments.Add(dbTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the comments of an entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommentModel> GetComments(int id)
        {
            List<CommentModel> response = new List<CommentModel>();
            var dataList = _context.desisComments.Where(c => c.DesisEntry.id.Equals(id)).ToList();

            dataList.ForEach(row => response.Add(
                new CommentModel(){
                    commentId = row.commentId,
                    comment = row.comment,
                    dateTime = row.dateTime,
                    DesisEntryId = id
                }));

            return response;
        }

        /// <summary>
        /// Gets the comments of a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommentModel> GetCommentsByUserId(int id)
        {
            List<CommentModel> response = new List<CommentModel>();
            var dataList = _context.desisComments.Where(u => u.DesisUser.id.Equals(id)).ToList();

            dataList.ForEach(row => response.Add(
                new CommentModel()
                {
                    commentId = row.commentId,
                    comment = row.comment,
                    dateTime = row.dateTime,
                    DesisEntryId = id,
                    DesisUserId = row.DesisUser.id
                }));

            return response;
        }

        /// <summary>
        /// Detele the comment
        /// </summary>
        /// <param name="id"></param>
        public void DeleteComment(int id)
        {
            var comment = _context.desisComments.Where(h => h.commentId.Equals(id)).FirstOrDefault();
            if (comment != null)
            {
                _context.desisComments.Remove(comment);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Save the new rating
        /// </summary>
        /// <param name="ratingModel"></param>
        public void SaveRating(RatingModel ratingModel)
        {
            DesisRating dbTable = new DesisRating();
            if (ratingModel.rateId > 0)
            {
                dbTable = _context.desisRatings.Where(r => r.rateId.Equals(ratingModel.rateId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.rating = ratingModel.rating;
                }
            }
            else
            {
                dbTable.rating = ratingModel.rating;
                dbTable.DesisEntry = ratingModel.DesisEntry;
                dbTable.DesisUser = ratingModel.DesisUser;
                _context.desisRatings.Add(dbTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the average rating
        /// </summary>
        /// <param name="id"></param>
        /// <returns>rating</returns>
        public int GetRating(int id)
        {
            int sumOfRatings = 0;
            var dataList = _context.desisRatings.Where(e => e.DesisEntry.id.Equals(id)).ToList();

            if (dataList.Count > 0)
            {
                dataList.ForEach(row => sumOfRatings = sumOfRatings + row.rating);

                int rating = sumOfRatings / dataList.Count;

                return rating;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>response</returns>
        public List<UserModel> GetUsers()
        {
            List<UserModel> response = new List<UserModel>();
            var dataList = _context.desisUsers.ToList();

            dataList.ForEach(row => response.Add(
                new UserModel()
                {
                    id = row.id,
                    name = row.name,
                    password = row.password,
                    university = row.university,
                    DesisComments = this.GetCommentsByUserId(row.id)
                }));

            return response;
        }

        /// <summary>
        /// Save the comment
        /// </summary>
        /// <param name="commentModel"></param>
        public void SaveUser(UserModel userModel)
        {
            DesisUser dbTable = new DesisUser();
            if (userModel.id > 0)
            {
                dbTable = _context.desisUsers.Where(d => d.id.Equals(userModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.name = userModel.name;
                    dbTable.email = userModel.email;
                    dbTable.password = userModel.password;
                    dbTable.studentNumber = userModel.studentNumber;
                    dbTable.university = userModel.university;
                }
            }
            else
            {
                dbTable.type = userModel.type;
                dbTable.name = userModel.name;
                dbTable.email = userModel.email;
                dbTable.password = userModel.password;
                dbTable.studentNumber = userModel.studentNumber;
                dbTable.university = userModel.university;
                _context.desisUsers.Add(dbTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// DELETE the user
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            var user = _context.desisUsers.Where(h => h.id.Equals(id)).FirstOrDefault();
            if (user != null)
            {
                _context.desisUsers.Remove(user);
                _context.SaveChanges();
            }
        }




    }
}

