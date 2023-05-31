using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class ProgrammeService : IProgrammeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProgrammeService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddAsync(ProgrammeVM_Input input)
        {
            Programme programme = new Programme { 
                Name = input.Name,
                Content = input.Content,
                Type_Inoff = input.Type_Inoff,
                Type_Program = input.Type_Program,
                Price = input.Price,
            };

            await unitOfWork.ProgrammeRepo.AddAsync(programme);
            await unitOfWork.CommitAsync();

            var listImage = mapper.Map<List<ProgrammeImage>>(input.ListProgrammeImage);

            foreach (var item in listImage)
            {
                item.ProgrammeId = programme.Id;
                await unitOfWork.ProgrammeImageRepo.AddAsync(item);
            }

            await unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var programme = await unitOfWork.ProgrammeRepo.GetByIdAsync(id);

                if (programme is null)
                    return 1;

                unitOfWork.ProgrammeRepo.Delete(programme);
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2; 
            }
        }

        public async Task<List<ProgrammeVM>> GetAllAsync()
            => mapper.Map<List<ProgrammeVM>>(await unitOfWork.ProgrammeRepo.GetAllAsync());

        public async Task<List<ProgrammeVM>> GetAllByTypeProgramAsync(int typeProgram)
            => mapper.Map<List<ProgrammeVM>>(await unitOfWork.ProgrammeRepo.GetAllByTypeProgramAsync(typeProgram));

        public async Task<ProgrammeVM_Details> GetDetailsAsync(int id)
            => mapper.Map<ProgrammeVM_Details>(await unitOfWork.ProgrammeRepo.GetByIdAsync(id));

        public async Task<int> UpdateAsync(int id, ProgrammeVM_Input input)
        {
            try
            {
                var programme = await unitOfWork.ProgrammeRepo.GetByIdAsync(id);

                if (programme == null)
                    return 1;

                programme.Name = input.Name;
                programme.Content = input.Content;
                programme.Price = input.Price;
                programme.Type_Program = input.Type_Program;
                programme.Type_Inoff = input.Type_Inoff;

                unitOfWork.ProgrammeRepo.Update(programme);
                await unitOfWork.CommitAsync();

                var countListImageInput = input.ListProgrammeImage.Count();
                var countListImage = programme.ListProgrammeImage.Count();

                for (int i = 0; i < countListImageInput; i++)
                {
                    var programmeImageInput = input.ListProgrammeImage[i];

                    if (i < countListImage)
                    {
                        var programmeImage = programme.ListProgrammeImage[i];

                        programmeImage.Image = programmeImageInput.Image;

                        unitOfWork.ProgrammeImageRepo.Update(programmeImage);
                    }
                    else
                    {
                        break;
                    }
                }

                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }
    }
}
