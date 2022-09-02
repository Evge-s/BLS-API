using BLS_API.Models;
using BLS_API.Models.Dto.Request;
using System.Threading.Tasks;

namespace BLS_API.Services
{
    public interface IBlsService
    {
        Task<BlsServiceResponse<string>> MultipleSeries(MultipleRequest request);
        Task<BlsServiceResponse<string>> OptionalParametersSeries(OptionalParametersRequest request);
        Task<BlsServiceResponse<string>> LatestSeriesData(LatestSeriesDataRequest request);
        Task<BlsServiceResponse<string>> PopularSeriesData(PopularSeriesRequest request);
        Task<BlsServiceResponse<string>> AllSurveysData();
        Task<BlsServiceResponse<string>> SingleSurveyData(SingleSurveyRequest request);
    }
}
