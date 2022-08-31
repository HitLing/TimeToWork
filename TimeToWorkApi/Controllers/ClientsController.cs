using TimeToWorkApi.ViewModels;
using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace TimeToWorkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IGenericRepository<Client> _repository;

        public ClientsController(IGenericRepository<Client> repository)
        {
            _repository = repository;
        }
        // GET: api/
        [HttpGet]
        public IEnumerable<ClientViewModel> Get()
        {
            var dbItems = _repository.GetList().Select(x => new ClientViewModel
            {
                ClientId= x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                Email = x.Email
            });
            return dbItems;
        }

        // GET api/
        [HttpGet("{id}")]
        public ClientViewModel Get(int id)
        {
            var dbItem = _repository.GetByIdOrNULL(id);

            var itemView = new ClientViewModel();

            if (null != dbItem)
            {
                itemView.ClientId = dbItem.Id;
                itemView.Name = dbItem.Name;
                itemView.Surname = dbItem.Surname;
                itemView.Phone = dbItem.Phone;
                itemView.Email = dbItem.Email;
            }

            return itemView;
        }

        // POST api/
        [HttpPost]
        public JsonResult Post([FromBody] ClientViewModel model)
        {
            var itemView = new Client
            {
                Id = model.ClientId,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                Email = model.Email
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
        public JsonResult Put(int id, [FromBody] ClientViewModel model)
        {
            if (id != model.ClientId)
            {
                return new JsonResult("Id неверен");
            }
            var itemView = new Client
            {
                Id = model.ClientId,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                Email = model.Email
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
