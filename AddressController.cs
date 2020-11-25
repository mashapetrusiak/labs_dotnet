using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using lab4.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class AddressController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;

        #endregion Fields

        #region Constructors

        public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _iMapper = mapper;
        }

        #endregion Constructors

        #region Methods

        // GET: Trades
        public async Task<IActionResult> ReturnToEmployee(int employeeId, int addressId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Employee", new { employeeId, addressId });
        }

        // GET: Trades/Create
        public IActionResult AddOrEdit(int employeeId, int addressId = -1)
        {
            var data = _iMapper.Map<AddressViewModel>(_unitOfWork.AddressRepository.GetAsync(x => addressId == -1 ? true : x.Id == addressId).Result.FirstOrDefault());
            ViewData["EmployeeId"] = employeeId;

            return addressId == -1 ? View(new AddressViewModel() { Id = -1 }) : View(data);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, City, Street, HouseNumber")]AddressViewModel address, int employeeId)
        {
            if (ModelState.IsValid)
            {
                int addressId = address.Id;
                if (addressId == -1)
                {
                    address.Id = 0;
                    var addressEntity = await _unitOfWork.AddressRepository.InsertAsync(_iMapper.Map<Address>(address));
                    await _unitOfWork.SaveAsync();
                    addressId = addressEntity.Entity.Id;
                }
                else
                {
                    _unitOfWork.AddressRepository.Update(_iMapper.Map<Address>(address));
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(ReturnToEmployee), new { employeeId, addressId });
            }
            return RedirectToAction(nameof(ReturnToEmployee), new { employeeId });
        }

        #endregion Methods
    }
}