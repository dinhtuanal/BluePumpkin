using API.Helpers;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IFileStorageHelper _fileStorageHelper;
        public EventsController(IEventService eventService, IFileStorageHelper fileStorageHelper)
        {
            _eventService = eventService;
            _fileStorageHelper = fileStorageHelper;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ResponseResult> Add( EventViewModel model)
        {
            var result = await _eventService.Add(model);

            if (result == 0)
            {
                return new ResponseResult(400, "Add failed !");
            }
            return new ResponseResult(200, "Add event success !");
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ResponseResult> Update(EventViewModel model)
        {
            var result = await _eventService.Update(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Update failed !");
            }
            return new ResponseResult(200, "Update success");
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _eventService.GetById(id);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseResult> Delete(string id)
        {
            var result = await _eventService.Delete(id);
            if (result == 0)
            {
                return new ResponseResult(400, "Delete failed !");
            }
            return new ResponseResult(200, "Delete event success");
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("uploadImg/{id}")]
        public async Task<string> UploadImage(string id,IFormFile file)
        {
            var imgUrl = await _fileStorageHelper.SaveFileAsync(file);
            var evt = await _eventService.GetById(id);
            var evtVM = new EventViewModel
            {
                EventId = id,
                EventName = evt.EventName,
                EventStatus = (int)evt.EventStatus,
                Title = evt.Title,
                Content = evt.Content,
                TimeStart = evt.TimeStart,
                TimeEnd = evt.TimeEnd,
                CreatedBy = evt.CreatedBy,
                ImgUrl = imgUrl,

            };
            var result = await _eventService.Update(evtVM);
            if (result == 0)
            {
                return "Can not upload image";
            }
            return imgUrl;

        }
    }
}
