using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBackgroundService.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LongRunningTaskController : ControllerBase
    {
        private readonly IBackgroundTaskQueue _taskQueue;

        public LongRunningTaskController(IBackgroundTaskQueue taskQueue)
        {
            _taskQueue = taskQueue;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _taskQueue.QueueBackgroundWorkItem(async token =>
            {
                await Task.Delay(10000);
            });

            return Accepted();
        }
    }
}
