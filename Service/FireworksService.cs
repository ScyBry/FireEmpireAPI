﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class FireworksService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public FireworksService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<FireworkDTO> CreateFirework(FireworkForCreationDTO firework, bool trackChanges)
        {
            var fireworkEntity = _mapper.Map<Firework>(firework);

            _repository.Firework.CreateFirework(fireworkEntity);
            await _repository.SaveAsync();

            var fireworkResponse = _mapper.Map<FireworkDTO>(fireworkEntity);
            return fireworkResponse;
            
        }

        public async Task DeleteFirework(Guid id)
        {
            var fireworkDb = await CheckIfFireworkExists(id);
            _repository.Firework.DeleteFirework(fireworkDb);
            await _repository.SaveAsync();

        }


        public async void ImportFireworksFromExcelAsync(IFormFile file)
        {
            using var package = new ExcelPackage(file.OpenReadStream());
            var worksheet = package.Workbook.Worksheets[0];

            var rowCount = worksheet.Dimension.Rows;
            var fireworks = new List<Firework>();


            for (int row = 20; row < rowCount; row++)
            {
                var firework = new Firework
                {
                    Name = worksheet.Cells[row, 1].Value?.ToString(),
                    Quantity = int.Parse(worksheet.Cells[row, 2].Value?.ToString() ?? "0"),
                    VideoLink = worksheet.Cells[row, 3].Value?.ToString(),
                    HazardClass = worksheet.Cells[row, 4].Value?.ToString(),
                    PricePerUnit = decimal.Parse(worksheet.Cells[row, 5].Value?.ToString() ?? "0"),
                    PricePerBox = decimal.Parse(worksheet.Cells[row, 6].Value?.ToString() ?? "0")
                };

                fireworks.Add(firework);
            }

            foreach (var firework in fireworks)
            {
                _repository.Firework.CreateFirework(firework);
            }

            await _repository.SaveAsync();
        }


        public async Task<byte[]> ExportFireworksToExcelAsync()
        {
            var fireworks = await _repository.Firework.GetAllFireworksAsync(trackChanges: false);

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Fireworks");
            worksheet.Cells[1, 1].Value = "Наименование";
            worksheet.Cells[1, 2].Value = "Количество";
            worksheet.Cells[1, 3].Value = "Ссылка на видео";
            worksheet.Cells[1, 4].Value = "Класс опасности";
            worksheet.Cells[1, 5].Value = "Цена за штуку";
            worksheet.Cells[1, 6].Value = "Цена за коробку";

            int row = 2;
            foreach (var firework in fireworks)
            {
                worksheet.Cells[row, 1].Value = firework.Name;
                worksheet.Cells[row, 2].Value = firework.Quantity;
                worksheet.Cells[row, 3].Value = firework.VideoLink;
                worksheet.Cells[row, 4].Value = firework.HazardClass;
                worksheet.Cells[row, 5].Value = firework.PricePerUnit;
                worksheet.Cells[row, 6].Value = firework.PricePerBox;
                row++;
            }

            return package.GetAsByteArray();
        }

        private async Task<Firework> CheckIfFireworkExists(Guid Id)
        {
            var fireworkDb = await _repository.Firework.GetFireworkByIdAsync(Id, trackChanges: false);
            
            return fireworkDb;
        }
    }

   
}