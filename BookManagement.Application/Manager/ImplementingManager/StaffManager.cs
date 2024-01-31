
using AutoMapper;
using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Helpers;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Services;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.ImplementingManager
{
    public class StaffManager : IStaffManager
    {
        private readonly IStaffService _service;
        private readonly IMapper _mapper;
        public StaffManager(IStaffService staffService, IMapper mapper)
        {
            _service = staffService;
            _mapper = mapper;
        }
        public async Task<ServiceResult<bool>> AddStaff(StaffRequestDTO staffRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var isPasswordValid = PasswordHasher.ValidatePassword(staffRequestDTO.Password);
                if (isPasswordValid == false)
                {
                    return new ServiceResult<bool>()
                    {
                        Data = false,
                        Message = "Incorrect password format, should be from 6 to 12 character, 1 uppercase, 1 lowercase and a special character",
                        Status = StatusType.Failure
                    };
                }
                var isUsernameUnique = await _service.IsUniqueUsername(staffRequestDTO.Username);
                if (isUsernameUnique == true)
                {
                    return new ServiceResult<bool>()
                    {
                        Data = false,
                        Message = "Email already exist!",
                        Status = StatusType.Failure
                    };
                }


                string hashedPassword = PasswordHasher.ComputeHash(staffRequestDTO.Password, PasswordHasher.Supported_HA.SHA256, null);
                staffRequestDTO.Password = hashedPassword;
                var staffDomain = _mapper.Map<Staff>(staffRequestDTO);
                var data = await _service.AddStaff(staffDomain);
                serviceResult.Status = data ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = data ? "Staff Created Successfully" : "Failed to create staff";
                serviceResult.Data = data;
                return serviceResult;
            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while creating the staff";
                serviceResult.Data = false;
                return serviceResult;

            }

        }

        public async Task<ServiceResult<bool>> DeleteStaff(Guid id)
        {
            var serviceResult = new ServiceResult<bool>();

            try
            {
                var staff = await _service.GetStaffById(id);
                if (staff == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Staff not found";
                    serviceResult.Data = false;

                    return serviceResult;
                }
                staff.DateDeleted = DateTime.Now;

                var result = await _service.UpdateStaff(staff);

                serviceResult.Status = result ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = result ? "Issue deleted successfully" : "Failed to delete issue";
                serviceResult.Data = result;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while deleting the issue";
                serviceResult.Data = false;

                return serviceResult;
            }
        }

        public async Task<ServiceResult<StaffResponseDTO>> GetStaffById(Guid id)
        {
            var serviceResult = new ServiceResult<StaffResponseDTO>();
            try
            {
                var staff = await _service.GetStaffById(id);
                if (staff == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Staff not found";
                    serviceResult.Data = null;
                    return serviceResult;
                }
                var bookResponse = _mapper.Map<StaffResponseDTO>(staff);

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Staff found sucessfully";
                serviceResult.Data = bookResponse;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while getting the staff";
                serviceResult.Data = null;

                return serviceResult;

            }
        }

        public async Task<ServiceResult<List<StaffResponseDTO>>> GetStaffs()
        {
          var serviceResult = new ServiceResult<List<StaffResponseDTO>>();

            try
            {
                var staffs = await _service.GetStaffs();
                var staffResponse = (from staff in staffs
                                     where staff.DateDeleted == null
                                     select new StaffResponseDTO()
                                     {
                                         StaffId = staff.StaffId,
                                         Username = staff.Username,
                                     }).ToList();

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Books retrieved successfully";
                serviceResult.Data = staffResponse;

                return serviceResult;

            }
            catch(Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while retrieving the books";
                serviceResult.Data = null;

                return serviceResult;
            }
           
        }

        public async Task<ServiceResult<bool>> UpdateStaffs(StaffResponseDTO staffResponseDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var staff = await _service.GetStaffById(staffResponseDTO.StaffId);
                if (staff == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Staff could not be found";
                    serviceResult.Data = false;
                    return serviceResult;
                }
                _mapper.Map(staffResponseDTO, staff);
                var result = _service.UpdateStaff(staff);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Staff Updated Sucessfully";
                serviceResult.Data = true;
                return serviceResult;

            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while retrieving the books";
                serviceResult.Data = false;

                return serviceResult;

            }
        }
    }
}
