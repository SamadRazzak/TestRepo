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
using DataAccessLayerMongoDB.Models;
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
    public class ProjectController : BaseController
    {
        private const string Screen = GlobalConstant.ScreenProject;
        private const MessageType CreateType = MessageType.CREATE_PROJECT;
        private const MessageType CloneType = MessageType.CLONE_PROJECT;
        private const MessageType UpdateType = MessageType.UPDATE_PROJECT;
        private const MessageType UpdateMainType = MessageType.UPDATE_PROJECT;
        private const MessageType SearchType = MessageType.SEARCH_PROJECT;
        private const MessageType DeleteType = MessageType.DELETE_PROJECT;
        private const MessageType ProjectUsers = MessageType.GET_PROJECT_USERS;
        private const MessageType MainProject = MessageType.GET_MAIN_PROJECT;
        private const MessageType UserProject = MessageType.GET_USERS_PROJECT;
        private const MessageType ProjectMessages = MessageType.GET_PROJECT_MESSAGES;
        private const MessageType CreateProject = MessageType.CREATE_PROJECT_MESSAGES;
        private const MessageType UpdateProgressFlagType = MessageType.CREATE_PROJECT_MESSAGES;


        private const string formID = GlobalConstant.transactiondesigner_project;

        [PermissionFilter(formID, PermissionActionType.View)]
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("Search")]
        public string Search(String search)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                ProjectModel model = null;
                if (search != null)
                    model = JsonConvert.DeserializeObject<ProjectModel>(search);

                if (model != null)
                    message.InitParamsDic(model);

                rspMsg = AvanzaCore.ProccessMessage(1, SearchType, message);
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
        ///[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Insert)]
        public string Create([FromBody] ProjectModel request)
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
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.Add.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }

                rspMsg = AvanzaCore.ProccessMessage(1, CreateType, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.Add.ToString(),
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
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("CloneProject")]
        public string CloneProject([FromBody] ProjectModel request)
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
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.Add.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }

                rspMsg = AvanzaCore.ProccessMessage(1, CloneType, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.Add.ToString(),
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
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Update)]
        public string Update([FromBody] ProjectModel request)
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
                rspMsg = AvanzaCore.ProccessMessage(1, UpdateType, message);
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
        [System.Web.Mvc.HttpPut, System.Web.Mvc.ActionName("UpdateMainProject")]
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Update)]
        public string UpdateMainProject([FromBody] Project request)
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
                rspMsg = AvanzaCore.ProccessMessage(1, UpdateMainType, message);
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
                Dictionary<string, string> porject = new Dictionary<string, string>();
                porject.Add("ID", ID);
                message.MsgData = porject;

                rspMsg = AvanzaCore.ProccessMessage(1, DeleteType, message);
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
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetProjectUsers")]
        public String GetProjectUsers(string ID)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                Dictionary<string, string> porject = new Dictionary<string, string>();
                porject.Add("ID", ID);
                message.MsgData = porject;

                rspMsg = AvanzaCore.ProccessMessage(1, ProjectUsers, message);
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
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetMainProject")]
        public String GetMainProject(string ID)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                Dictionary<string, string> porject = new Dictionary<string, string>();
                porject.Add("ID", ID);
                message.MsgData = porject;

                rspMsg = AvanzaCore.ProccessMessage(1, MainProject, message);
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
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetUserProject")]
        public String GetUserProject(string ID)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                Dictionary<string, string> porject = new Dictionary<string, string>();
                porject.Add("ID", ID);
                message.MsgData = porject;

                rspMsg = AvanzaCore.ProccessMessage(1, UserProject, message);
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
        [System.Web.Mvc.HttpGet, System.Web.Mvc.ActionName("GetProjectMessages")]
        public String GetProjectMessages(string ID)
        {
            IProcessMessage message = new BizMessage(Request.Headers);
            IProcessMessage rspMsg = new BizMessage();
            APIResponse apiResponse = new APIResponse(new DateTime());
            try
            {
                Dictionary<string, string> porject = new Dictionary<string, string>();
                porject.Add("ID", ID);
                message.MsgData = porject;

                rspMsg = AvanzaCore.ProccessMessage(1, ProjectMessages, message);
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
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("CreateProjectMessage")]
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Insert)]
        public string CreateProjectMessage([FromBody] ProjectMessageModel request)
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
                    ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Executing Method {0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ActionType.Add.ToString(), message.EntityId, message.LoginId, message.MachineName, this.GetType().Name, Screen + " data required", 0);

                    throw new Exception(Screen + " data required");
                }

                rspMsg = AvanzaCore.ProccessMessage(1, CreateProject, message);
                ActivityLogger.Instance.SystemLog(
                    LogLevel.Info,
                    string.Format("Executing Method {0}.", MethodBase.GetCurrentMethod().Name),
                    ActionType.Add.ToString(),
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
        [System.Web.Mvc.HttpPut, System.Web.Mvc.ActionName("UpdateProgressFlag")]
        //[ValidationFilter(Avanza.Common.BusinessModels.Base.OperationType.Update)]
        public string UpdateProgressFlag([FromBody] ProjectModel request)
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
                rspMsg = AvanzaCore.ProccessMessage(1, UpdateProgressFlagType, message);
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
