using TimeToWorkApi.ViewModels;
using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace TimeToWorkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : Controller
    {
        private readonly IGenericRepository<Job> _repository;

        public JobsController(IGenericRepository<Job> repository)
        {
            _repository = repository;
        }

        // GET api/<CoursesController>/5
        [HttpGet]
        public IEnumerable<JobViewModel> Get()
        {
            var dbItems = _repository.GetList().Select(x => new JobViewModel {
                JobId = x.Id,
                Name = x.Name,
                Salary = x.Salary,
                Description = x.Description,
                JobContent = x.JobContent
            });
            return dbItems;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public JobViewModel Get(int id)
        {
            var dbItem = _repository.GetByIdOrNULL(id);

            var itemView = new JobViewModel();

            if(null != dbItem)
            {
                itemView.JobId = dbItem.Id;
                itemView.Name = dbItem.Name;
                itemView.Salary = dbItem.Salary;
                itemView.Description = dbItem.Description;
                itemView.JobContent = dbItem.JobContent;
            }

            return itemView;
        }

        // POST api/
        [HttpPost]
        public JsonResult Post([FromBody] JobViewModel model)
        {
            var itemView = new Job
            {
                Id = model.JobId,
                Name = model.Name,
                Salary = model.Salary,
                Description = model.Description,
                JobContent = model.JobContent
            };

            try
            {
                _repository.Create(itemView);

                return new JsonResult($"Запись создана под id = { itemView.Id }");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // PUT api/
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] JobViewModel model)
        {
            if (id != model.JobId)
            {
                return new JsonResult("Id неверен");
            }
            var itemView = new Job
            {
                Id = model.JobId,
                Name = model.Name,
                Salary = model.Salary,
                Description = model.Description,
                JobContent = model.JobContent
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
