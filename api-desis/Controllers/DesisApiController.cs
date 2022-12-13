using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_desis.DesisEfCore;
using api_desis.Model;
using Microsoft.AspNetCore.Mvc;
using static api_desis.Model.ApiResponse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_desis.Controllers
{
    
    [ApiController]
    public class DesisApiController : Controller
    {
        private readonly DbHelper _db;
        public DesisApiController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);

        }

        //entry methods
        // GET: api/<DesisApiController>
        [HttpGet]
        [Route("api/[controller]/GetEntries")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EntryModel> data = _db.GetEntries();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<DesisApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetEntryById/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DesisApiController>
        [HttpPost]
        [Route("api/[controller]/SaveEntry")]
        public IActionResult Post([FromBody] EntryModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEntry(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<DesisApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateEntry")]
        public IActionResult Put([FromBody] EntryModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEntry(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<DesisApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteEntry/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteEntry(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        //end of entry methods

        //user methods
        // GET: api/<DesisApiController>
        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public IActionResult GetUsers()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UserModel> data = _db.GetUsers();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
        // POST api/<DesisApiController>
        [HttpPost]
        [Route("api/[controller]/SaveUser")]
        public IActionResult Post([FromBody] UserModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUser(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<DesisApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult Put([FromBody] UserModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUser(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<DesisApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUser(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        //end of User methods

        //comment methods
        // GET: api/<DesisApiController>
        [HttpGet]
        [Route("api/[controller]/GetComments/{id}")]
        public IActionResult GetComments(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<CommentModel> data = _db.GetComments(id);

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<DesisApiController>
        [HttpPost]
        [Route("api/[controller]/SaveComment")]
        public IActionResult Post([FromBody] CommentModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveComment(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<DesisApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateComment")]
        public IActionResult Put([FromBody] CommentModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveComment(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<DesisApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteComment(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        //end of comment methods
    }
}

