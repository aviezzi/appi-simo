namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class LightService : IResourceService<Light>
    {
        readonly IGraphQlService<Light> _service;

        public LightService(IGraphQlService<Light> service)
        {
            _service = service;
        }

        public async Task<ICollection<Light>> GetAsync()
        {
            const string query =
                @"
 				{
				    allLights {
				        nodes {
				            id,
				            lightType,
							price,
							enabled
				        }
				    }
				}
				";

            return await _service.GetAll(query, "allLights");
        }

        public async Task<Light> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetLightById($id: UUID!) {
					lightById(id: $id) {
						id,
						lightType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "lightById", key);

            return result;
        }
		
		public async Task<Light> UpdateAsync(Light light)
		{
			const string query = 
				@"
				mutation UpdateLecturer($input: UpdateLecturerByIdInput!) {
				  updateLecturerById(input: $input) {
					lecturer {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await _service.Mutate(query, "updateLecturerById.lecturer", new
			{
//				input = new {
//					id = lecturer.Id,
//					lecturerPatch = new {
//						lecturerName = lecturer.LecturerName,
//						surname = lecturer.Surname,
//						pulpitId = lecturer.PulpitId,
//						lecturerType = lecturer.LecturerType,
//						gender = lecturer.Gender,
//						birthYear = lecturer.BirthYear,
//						children = lecturer.Children,
//						salary = lecturer.Salary
//					}
//				}
			});
		}
		
		public async Task<Light> AddAsync(Light light)
		{
			const string query = 
				@"
				mutation AddLecturer($input: CreateLecturerInput!) {
				  createLecturer(input: $input) {
					lecturer {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await _service.Mutate(query, "createLecturer.lecturer", new
			{
//				input = new {
//					lecturer = new {
//						lecturerName = light.LecturerName,
//						surname = light.Surname,
//						pulpitId = light.PulpitId,
//						lecturerType = light.LecturerType,
//						gender = light.Gender,
//						birthYear = light.BirthYear,
//						children = light.Children,
//						salary = light.Salary
//					}
//				}
			});
		}
		
    }
}