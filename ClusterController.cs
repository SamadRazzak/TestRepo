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
    public class ClusterController : BaseController
    {
        private const string Screen = GlobalConstant.ScreenNetwork;
        private const MessageType CreateType = MessageType.CREATE_NETWORK;
        private const MessageType UpdateType = MessageType.UPDATE_NETWORK;
        private const MessageType SearchType = MessageType.SEARCH_NETWORK;
        private const MessageType DeleteType = MessageType.DELETE_NETWORK;
        private const MessageType GetNetworkList = MessageType.GET_NETWORK_LIST;


        private const string formID = GlobalConstant.transactiondesigner_cluster;

        [PermissionFilter(formID, PermissionActionType.View)]
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("Search")]
        public string Search(String search)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                ClusterModel model = null;
                if (search != null)
                    model = JsonConvert.DeserializeObject<ClusterModel>(search);

                if (model != null)
                    message.InitParamsDic(model);

                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.TRAN_DESIGNER_GET_CLUSTERS, message);
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
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("create")]
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Update)]
        public string create([FromBody] ClusterModel request)
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
                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.TRAN_DESIGNER_ADD_CLUSTERS, message);
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
        [System.Web.Mvc.HttpPut, System.Web.Mvc.ActionName("update")]
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Update)]
        public string Update([FromBody] ClusterModel request)
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
                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.TRAN_DESIGNER_UPDATE_CLUSTERS, message);
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

                rspMsg = AvanzaCore.ProccessMessage(1, MessageType.TRAN_DESIGNER_DELETE_CLUSTERS, message);
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

        [PermissionFilter(GlobalConstant.transactiondesigner_cluster, PermissionActionType.View)]
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetClusterConfigById")]
        public string GetClusterConfigById(string id)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            try
            {


                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("ID", id);
                message.MsgData = param;


                rspMsg = AvanzaCore.ProccessMessage(1, Common.Enums.MessageType.TRAN_DESIGNER_GET_CLUSTER_BY_CODE, message);

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

            return JsonConvert.SerializeObject(rspMsg);
        }

    }
}