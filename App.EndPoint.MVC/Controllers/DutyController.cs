namespace App.EndPoint.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DutyController : Controller
    {
        private readonly IDutyAppService _DutyAppServices;
        private readonly UserManager<User> _userManager;

        public DutyController(IDutyAppService dutyAppService, UserManager<User> userManager)
        {
            _DutyAppServices = dutyAppService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            var userId = _userManager.GetUserId(User);
            var id = int.Parse(userId);
            var number = await _DutyAppServices.NumberDuty(id, cToken);

            ViewBag.TaskCount = number;
            var tasks = await _DutyAppServices.GetAllDuties(id, cToken);

            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Duty model, CancellationToken cToken)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                model.UserId = int.Parse(userId);
                var result = await _DutyAppServices.CreateDuty(model, cToken);
                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = result.IsMessage;
                }
                else
                {
                    TempData["ErrorMessage"] = result.IsMessage;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Preview(int id, CancellationToken cToken)
        {
            var model = await _DutyAppServices.GetDutyById(id, cToken);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cToken)
        {
            var userId = _userManager.GetUserId(User);
            var id1 = int.Parse(userId);
            var model = await _DutyAppServices.GetDutyById(id, cToken);
            if (model == null || model.UserId != id1)
                return NotFound();
            await _DutyAppServices.DeleteDuty(id, cToken);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cToken)
        {
            var userId = _userManager.GetUserId(User);
            var id1 = int.Parse(userId);
            var model = await _DutyAppServices.GetDutyById(id, cToken);
            if (model == null || model.UserId != id1)
                return NotFound();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Duty model, CancellationToken cToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _DutyAppServices.UpdateDuty(model, cToken);
                if (result.IsSuccess)
                {
                    ViewBag.SuccessMessage = result.IsMessage;
                }
                else
                {
                    ViewBag.ErrorMessage = result.IsMessage;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EndTask(int id, CancellationToken cToken)
        {
            var userId = _userManager.GetUserId(User);
            var id1 = int.Parse(userId);
            var model = await _DutyAppServices.GetDutyById(id, cToken);
            if (model == null || model.UserId != id1)
                return NotFound();
            var result = await _DutyAppServices.EndDuty(id, cToken);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;
            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
