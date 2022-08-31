using TimeToWorkApi.ViewModels;
using BLL.Entities;
using BLL.IRepositories;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TimeToWorkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobrequestController : ControllerBase
    {
        private readonly IGenericRepository<Jobrequest> _repository;
        private readonly DAL.TimeToWorkContext _context;

        public JobrequestController(IGenericRepository<Jobrequest> repository, DAL.TimeToWorkContext context)
        {
            _repository = repository;
            _context = context;
        }
        // GET: api/
        [HttpGet]
        public List<JobrequestViewModel> Get()
        {
            var itemsDb = _context.Jobrequests.Include(s => s.Client).Include(s => s.Job).ToList();
            var itemsView = new List<JobrequestViewModel>();

            foreach(var item in itemsDb)
            {
                var itemView = new JobrequestViewModel
                {
                    JobrequestId = item.Id,
                    PaymentDate = item.RequestDate,
                    ClientId = item.ClientId,
                    JobId = item.JobId,
                    ClientFullName = item.Client?.Name + " " + item.Client?.Surname,
                    JobName = item.Job?.Name
                };


                itemsView.Add(itemView);
            }

            return itemsView;
        }

        // GET api/
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/
        [HttpPost]
        public JsonResult Post([FromBody] JobrequestViewModel model)
        {
            var itemView = new Jobrequest
            {
                Id = model.JobrequestId,
                ClientId = model.ClientId,
                JobId = model.JobId,
                RequestDate = model.PaymentDate
            };

            try
            {
                _context.Jobrequests.Add(itemView);
                _context.SaveChanges();
                _context.SaveChanges(); 

                return new JsonResult($"Запись создана под id = { itemView.Id }");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // PUT api/
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] JobrequestViewModel model)
        {
            if (id != model.JobrequestId)
            {
                return new JsonResult("Id неверен");
            }
            var itemView = new Jobrequest
            {
                Id = model.JobrequestId,
                ClientId = model.ClientId,
                JobId = model.JobId,
                RequestDate = model.PaymentDate
            };

            try
            {
                _repository.Update(itemView);              
                return new JsonResult($"Запись успешна обновлена");
            }
            catch
            {
                return new JsonResult("Ошибка при обновлении записи");
            }
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            if (_repository.Delete(id))
            {
                return new JsonResult("Запись успешна удалена");
            }
            else
            {
                return new JsonResult("Ошибка при удалении записи");
            }
        }
    }
}
