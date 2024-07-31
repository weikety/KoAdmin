using Microsoft.AspNetCore.Mvc;

namespace Ko.Api.Admin.Controllers.Sys
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("Api/Sys/[controller]/[action]")]
    [Produces("application/json")] //返回数据的格式 直接约定为Json
    public class SysConfigController : Controller
    {

        private readonly SysConfigService _sysConfigService;

        public SysConfigController(SysConfigService sysConfigService)
        {
            _sysConfigService = sysConfigService;
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var list = await _sysConfigService.GetList();

            return new JsonResult(list);
        }
    }
}
