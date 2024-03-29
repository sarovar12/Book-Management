﻿using AutoMapper;
using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Application.Utils;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.ImplementingManager
{
    public class IssueManager : IIssueManager
    {
        private readonly IIssueService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IssueManager(IIssueService issueService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _service = issueService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<ServiceResult<bool>> AddIssue(IssueRequestDTO issueRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            string username = JwtTokenServices.GetUsernameFromToken(_httpContextAccessor.HttpContext);
            try
            {
                var issueDomain = new Issue()
                {
                    BookId = issueRequestDTO.BookId,
                    StudentId = issueRequestDTO.StudentId,
                    Fine = issueRequestDTO.Fine,
                    IsAvailable = issueRequestDTO.IsAvailable,
                    IssuerName = username
                };
                var data = await _service.AddIssuedService(issueDomain);
                serviceResult.Status = data ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = data ? "Book Issued sucessfully" : "Failed to Issue Book";
                serviceResult.Data = data;
                return serviceResult;
            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occured while issuing a book";
                serviceResult.Data = false;
                return serviceResult;

            }
        }

        public async Task<ServiceResult<bool>> DeleteIssue(Guid id)
        {
            var serviceResult = new ServiceResult<bool>();

            try
            {
                var issue = await _service.GetIssuedServiceById(id);
                if (issue == null)
                {
                    // Book does not exist
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Issue not found";
                    serviceResult.Data = false;

                    return serviceResult;
                }
                issue.DateDeleted = DateTime.Now;

                var result = await _service.UpdateIssuedService(issue);

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

        public async Task<ServiceResult<IssueResponseDTO>> GetIssueById(Guid id)
        {
            var serviceResult = new ServiceResult<IssueResponseDTO>();
            try
            {
                var issue = await _service.GetIssuedServiceById(id);
                if (issue == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Issue not found";
                    serviceResult.Data = null;
                    return serviceResult;
                }
                var bookResponse = _mapper.Map<IssueResponseDTO>(issue);

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Issue retrieved successfully";
                serviceResult.Data = bookResponse;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while retrieving the issue";
                serviceResult.Data = null;

                return serviceResult;

            }
        }

        public async Task<ServiceResult<List<IssueResponseDTO>>> GetIssues()
        {
            var serviceResult = new ServiceResult<List<IssueResponseDTO>>();
            try
            {
                var issues = await _service.GetIssuedServices();
                var result = (from issue in issues
                              where issue.DateDeleted == null
                              select new IssueResponseDTO()
                              {
                                  IssueId = issue.IssueId,
                                  IsAvailable = issue.IsAvailable,
                                  IssuedDate = issue.IssuedDate,
                                  Fine = issue.Fine,
                                  BookId = issue.BookId,
                                  ExpectedReturnDate = issue.ExpectedReturnDate,
                                  StudentId = issue.StudentId,
                                  IssuerName = issue.IssuerName
                              }).ToList();

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Issues retrieved successfully";
                serviceResult.Data = result;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while issuing the books";
                serviceResult.Data = null;

                return serviceResult;
            }
        }

        public Task<ServiceResult<bool>> ReturnIssuedBook(IssueResponseDTO issueResponseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<bool>> UpdateIssue(IssueUpdateResponseDTO issueRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            string username = JwtTokenServices.GetUsernameFromToken(_httpContextAccessor.HttpContext);
            try
            {
                var issue = await _service.GetIssuedServiceById(issueRequestDTO.IssueId);
                if (issue == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Issue could not be found";
                    serviceResult.Data = false;
                    return serviceResult;
                }
                _mapper.Map(issueRequestDTO, issue);
                issue.IssuerName = username;
                var result = _service.UpdateIssuedService(issue);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Issue Updated Successfully";
                serviceResult.Data = true;
                return serviceResult;
            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while retrieving the issues";
                serviceResult.Data = false;
                return serviceResult;
            }
        }


    }
}
