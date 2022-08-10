using BLS_API.Models;
using BLS_API.Models.Dto.Request;
using System.Threading.Tasks;

namespace BLS_API.Services
{
    public interface IBlsService
    {
        Task<BlsServiceResponse<string>> MultipleSeries(MultipleReqest request);
        Task<BlsServiceResponse<string>> OptionalParametersSeries(OptionalParametersReqest request);
        Task<BlsServiceResponse<string>> LatestSeriesData(LatestSeriesDataReqest request);
        Task<BlsServiceResponse<string>> PopularSeriesData(PopularSeriesReqest request);
        Task<BlsServiceResponse<string>> AllSurveysData();
        Task<BlsServiceResponse<string>> SingleSurveyData(SingleSurveyReqest request);
    }
}
