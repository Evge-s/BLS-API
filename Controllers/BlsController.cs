using BLS_API.Models;
using BLS_API.Models.Dto.Request;
using BLS_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BLS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlsController : ControllerBase
    {
        private readonly IBlsService _blsService;

        public BlsController(IBlsService blsService)
        {
            _blsService = blsService;
        }

        [HttpPost]
        public async Task Create(BlsUserRequest request)
        {

        }

        [HttpPut]
        public async Task Update(BlsUserRequest request)
        {

        }

        [HttpDelete]
        public async Task Delete(BlsUserRequest request)
        {

        }

        /// <summary>
        /// Use this signature to retrieve data for a single time series for the past three years.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("singleseries")]
        public async Task<ActionResult<BlsServiceResponse<string>>> SingleSeries(MultipleReqest request)
        {
            var result = await _blsService.MultipleSeries(request);
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve data for more than one timeseries for the past three years. 
        /// Registered users can include up to 50 series IDs, each separated with a comma, in the body of a request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multipleseries")]
        public async Task<ActionResult<BlsServiceResponse<string>>> MultipleSeries(MultipleReqest request)
        {
            var result = await _blsService.MultipleSeries(request);
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve data for one or more timeseries within a set time frame of up to 20 years. 
        /// This signature also provides the option of retrieving calculations, annual averages, aspects, and catalog data. 
        /// To retrieve these optional parameters, users must include their assigned registration key. 
        /// Unless otherwise specified, the catalog, calculations, annualaverage and aspects values will default to false.
        /// Users should also include at least one series ID, the start year, and the end year in the body of the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("optionalparametersSeries")]
        public async Task<ActionResult<BlsServiceResponse<string>>> OptionalParametersSeries(OptionalParametersReqest request)
        {
            var result = await _blsService.OptionalParametersSeries(request);
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve the most recent data point for a given BLS series ids.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("latestseriesdata")]
        public async Task<ActionResult<BlsServiceResponse<string>>> LatestSeriesData(LatestSeriesDataReqest request)
        {
            var result = await _blsService.LatestSeriesData(request);
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve a list of series IDs for the 25 most popular BLS and survey-specific series. 
        /// Parameters for retrieving series IDs for survey-specific series are optional.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("popularseries")]
        public async Task<ActionResult<BlsServiceResponse<string>>> PopularSeries(PopularSeriesReqest request)
        {
            var result = await _blsService.PopularSeriesData(request);
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve a list of all BLS surveys.
        /// </summary>
        /// <returns></returns>
        [HttpPost("allsurveys")]
        public async Task<ActionResult<BlsServiceResponse<string>>> AllSurveys()
        {
            var result = await _blsService.AllSurveysData();
            return Ok(result);
        }

        /// <summary>
        /// Use this signature to retrieve the metadata associated with a single BLS survey. 
        /// Be sure to include the specific survey abbreviation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("singlesurvey")]
        public async Task<ActionResult<BlsServiceResponse<string>>> SingleSurvey(SingleSurveyReqest request)
        {
            var result = await _blsService.SingleSurveyData(request);
            return Ok(result);
        }
    }
}
