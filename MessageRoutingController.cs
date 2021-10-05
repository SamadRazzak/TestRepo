using Avanza.Common.BusinessModels.Common;
using Avanza.Common.BusinessProcess;
using Avanza.Common.Enums;
using Avanza.Common.Logging;
using Avanza.Core;
using Avanza.Web.REST.ActionFilters;
using Avanza.Web.REST.Helpers;
using Common;
using Common.BusinessModels.Housekeeping;
using Common.BusinessModels.SystemConfiguration;
using Common.BusinessModels.TransactionDesigner;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Avanza.Web.REST.Controllers.TransactionDesigner
{
    public class MessageRoutingController : BaseController
    {
        private const string Screen = GlobalConstant.ScreenMessageRouting;
            private const string formID = GlobalConstant.transactiondesigner_msgrouting;

        [PermissionFilter(formID, PermissionActionType.View)]
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("Search")]
        public string GetAllMessageRouting(String search)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                MessageRoutingModel model = null;
                if (search != null)
                    model = JsonConvert.DeserializeObject<MessageRoutingModel>(search);

                if (model != null)
                    message.InitParamsDic(model);

                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_SEARCH, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);

            }

            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }


        [PermissionFilter(formID, PermissionActionType.View)]
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetMessageFieldsByNetwork")]
        public string GetMessageFieldsByNetwork(String search)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                MessageRoutingModel model = null;
                if (search != null)
                    model = JsonConvert.DeserializeObject<MessageRoutingModel>(search);

                if (model != null)
                    message.InitParamsDic(model);

                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_MSG_FIELDS, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);

            }

            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }

        [PermissionFilter(formID, PermissionActionType.Insert)]
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Create")]
        public string Create([FromBody] MessageRoutingModel request)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                if (request != null)
                {
                    message.MsgObjData = request;
                }
                else
                {
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.View.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }
                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_ADD, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);
            }

            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }

        [PermissionFilter(formID, PermissionActionType.Update)]
        [System.Web.Mvc.HttpPut, System.Web.Mvc.ActionName("Update")]
        public string Update([FromBody] MessageRoutingModel request)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                if (request != null)
                {
                    message.MsgObjData = request;
                }
                else
                {
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.View.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }
                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_UPDATE, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);
            }

            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }


        [PermissionFilter(formID, PermissionActionType.Update)]
        [System.Web.Mvc.HttpPut, System.Web.Mvc.ActionName("Reorder")]
        public string Reorder([FromBody] ProjectModel request)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                if (request != null)
                {
                    message.MsgObjData = request;
                }
                else
                {
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.View.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }
                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_REORDER, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);
            }

            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }

        [PermissionFilter(formID, PermissionActionType.Delete)]
        [System.Web.Mvc.HttpDelete, System.Web.Mvc.ActionName("Delete")]
        public String Delete(string ID)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                Dictionary<string, string> msgVariation = new Dictionary<string, string>();
                msgVariation.Add("ID", ID);
                message.MsgData = msgVariation;

                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.MSG_ROUTING_DELETE, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    1);
            }
            catch (Exception ex)
            {
                rspMsg.Message = "Some exception occured, details are: " + ex.Message.ToString();
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Error,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.View.ToString(),
                    message.EntityId, message.LoginId,
                    message.MachineName,
                    this.GetType().Name,
                    rspMsg.Message,
                    0, ex);

            }
            apiResponse = ResponseHelper.finalizeApiResponse(apiResponse, rspMsg);
            return SerilizationHelper.serializeObject<APIResponse>(apiResponse);
        }

    }
}