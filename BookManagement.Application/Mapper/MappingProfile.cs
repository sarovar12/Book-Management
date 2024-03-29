﻿
using AutoMapper;
using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Domain.Entities;

namespace BookManagement.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookRequestDTO>().ReverseMap();
            CreateMap<Book, BookResponseDTO>().ReverseMap();
            CreateMap<Student, StudentRequestDTO>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<Issue, IssueRequestDTO>().ReverseMap();
            CreateMap<Issue,IssueResponseDTO>().ReverseMap();
            CreateMap<IssueUpdateResponseDTO, Issue>().ReverseMap();
            CreateMap<Staff, StaffRequestDTO>().ReverseMap();
            CreateMap<Staff, StaffResponseDTO>().ReverseMap();
            
        }
    }

}
