﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.3.0.0 (NJsonSchema v10.1.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IDashboardClient {
    getInitialIssueList(): Observable<IssuesVm[]>;
    updateIssuePriority(command: UpdateIssuePriorityCommand): Observable<boolean>;
    getIssueCountByType(): Observable<IssuesCountVm[]>;
    getDailyBurnDowns(): Observable<DailyBurnDownVm[]>;
}

@Injectable({
    providedIn: 'root'
})
export class DashboardClient implements IDashboardClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    getInitialIssueList(): Observable<IssuesVm[]> {
        let url_ = this.baseUrl + "/api/Dashboard/InitialIssuesList";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetInitialIssueList(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetInitialIssueList(<any>response_);
                } catch (e) {
                    return <Observable<IssuesVm[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<IssuesVm[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetInitialIssueList(response: HttpResponseBase): Observable<IssuesVm[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(IssuesVm.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<IssuesVm[]>(<any>null);
    }

    updateIssuePriority(command: UpdateIssuePriorityCommand): Observable<boolean> {
        let url_ = this.baseUrl + "/api/Dashboard/UpdateIssuePriority";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdateIssuePriority(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateIssuePriority(<any>response_);
                } catch (e) {
                    return <Observable<boolean>><any>_observableThrow(e);
                }
            } else
                return <Observable<boolean>><any>_observableThrow(response_);
        }));
    }

    protected processUpdateIssuePriority(response: HttpResponseBase): Observable<boolean> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<boolean>(<any>null);
    }

    getIssueCountByType(): Observable<IssuesCountVm[]> {
        let url_ = this.baseUrl + "/api/Dashboard/GetIssuesCountByType";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetIssueCountByType(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetIssueCountByType(<any>response_);
                } catch (e) {
                    return <Observable<IssuesCountVm[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<IssuesCountVm[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetIssueCountByType(response: HttpResponseBase): Observable<IssuesCountVm[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(IssuesCountVm.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<IssuesCountVm[]>(<any>null);
    }

    getDailyBurnDowns(): Observable<DailyBurnDownVm[]> {
        let url_ = this.baseUrl + "/api/Dashboard/GetBurnDownData";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetDailyBurnDowns(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetDailyBurnDowns(<any>response_);
                } catch (e) {
                    return <Observable<DailyBurnDownVm[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<DailyBurnDownVm[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetDailyBurnDowns(response: HttpResponseBase): Observable<DailyBurnDownVm[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(DailyBurnDownVm.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<DailyBurnDownVm[]>(<any>null);
    }
}

export class IssuesVm implements IIssuesVm {
    issueId?: number;
    statusName?: string | undefined;
    issueDetailsId?: number;
    subject?: string | undefined;
    description?: string | undefined;
    assignedTo?: string | undefined;
    tags?: string | undefined;
    issueStatusId?: number;
    createdBy?: string | undefined;
    order?: number;
    issueTypeId?: number;
    sprintId?: number;
    attachment?: string | undefined;
    reporter?: string | undefined;
    environment?: string | undefined;
    browser?: string | undefined;
    acceptanceCriteria?: string | undefined;
    storyPoints?: number;
    epic?: number;
    uat?: boolean;
    timeTracking?: string | undefined;

    constructor(data?: IIssuesVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.issueId = _data["issueId"];
            this.statusName = _data["statusName"];
            this.issueDetailsId = _data["issueDetailsId"];
            this.subject = _data["subject"];
            this.description = _data["description"];
            this.assignedTo = _data["assignedTo"];
            this.tags = _data["tags"];
            this.issueStatusId = _data["issueStatusId"];
            this.createdBy = _data["createdBy"];
            this.order = _data["order"];
            this.issueTypeId = _data["issueTypeId"];
            this.sprintId = _data["sprintId"];
            this.attachment = _data["attachment"];
            this.reporter = _data["reporter"];
            this.environment = _data["environment"];
            this.browser = _data["browser"];
            this.acceptanceCriteria = _data["acceptanceCriteria"];
            this.storyPoints = _data["storyPoints"];
            this.epic = _data["epic"];
            this.uat = _data["uat"];
            this.timeTracking = _data["timeTracking"];
        }
    }

    static fromJS(data: any): IssuesVm {
        data = typeof data === 'object' ? data : {};
        let result = new IssuesVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["issueId"] = this.issueId;
        data["statusName"] = this.statusName;
        data["issueDetailsId"] = this.issueDetailsId;
        data["subject"] = this.subject;
        data["description"] = this.description;
        data["assignedTo"] = this.assignedTo;
        data["tags"] = this.tags;
        data["issueStatusId"] = this.issueStatusId;
        data["createdBy"] = this.createdBy;
        data["order"] = this.order;
        data["issueTypeId"] = this.issueTypeId;
        data["sprintId"] = this.sprintId;
        data["attachment"] = this.attachment;
        data["reporter"] = this.reporter;
        data["environment"] = this.environment;
        data["browser"] = this.browser;
        data["acceptanceCriteria"] = this.acceptanceCriteria;
        data["storyPoints"] = this.storyPoints;
        data["epic"] = this.epic;
        data["uat"] = this.uat;
        data["timeTracking"] = this.timeTracking;
        return data; 
    }
}

export interface IIssuesVm {
    issueId?: number;
    statusName?: string | undefined;
    issueDetailsId?: number;
    subject?: string | undefined;
    description?: string | undefined;
    assignedTo?: string | undefined;
    tags?: string | undefined;
    issueStatusId?: number;
    createdBy?: string | undefined;
    order?: number;
    issueTypeId?: number;
    sprintId?: number;
    attachment?: string | undefined;
    reporter?: string | undefined;
    environment?: string | undefined;
    browser?: string | undefined;
    acceptanceCriteria?: string | undefined;
    storyPoints?: number;
    epic?: number;
    uat?: boolean;
    timeTracking?: string | undefined;
}

export class UpdateIssuePriorityCommand implements IUpdateIssuePriorityCommand {
    prevItem?: boolean;
    prevItemId?: number;
    nextItemId?: number;
    currentItemIndex?: number;
    issueStatus?: number;
    issueId?: number;

    constructor(data?: IUpdateIssuePriorityCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.prevItem = _data["prevItem"];
            this.prevItemId = _data["prevItemId"];
            this.nextItemId = _data["nextItemId"];
            this.currentItemIndex = _data["currentItemIndex"];
            this.issueStatus = _data["issueStatus"];
            this.issueId = _data["issueId"];
        }
    }

    static fromJS(data: any): UpdateIssuePriorityCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateIssuePriorityCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["prevItem"] = this.prevItem;
        data["prevItemId"] = this.prevItemId;
        data["nextItemId"] = this.nextItemId;
        data["currentItemIndex"] = this.currentItemIndex;
        data["issueStatus"] = this.issueStatus;
        data["issueId"] = this.issueId;
        return data; 
    }
}

export interface IUpdateIssuePriorityCommand {
    prevItem?: boolean;
    prevItemId?: number;
    nextItemId?: number;
    currentItemIndex?: number;
    issueStatus?: number;
    issueId?: number;
}

export class IssuesCountVm implements IIssuesCountVm {
    typeName?: string | undefined;
    issueCount?: number;

    constructor(data?: IIssuesCountVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.typeName = _data["typeName"];
            this.issueCount = _data["issueCount"];
        }
    }

    static fromJS(data: any): IssuesCountVm {
        data = typeof data === 'object' ? data : {};
        let result = new IssuesCountVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["typeName"] = this.typeName;
        data["issueCount"] = this.issueCount;
        return data; 
    }
}

export interface IIssuesCountVm {
    typeName?: string | undefined;
    issueCount?: number;
}

export class DailyBurnDownVm implements IDailyBurnDownVm {
    dailyBurnDownId?: number;
    sprintId?: number;
    date?: Date;
    pointsCompleted?: number;
    pointsPending?: number;

    constructor(data?: IDailyBurnDownVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.dailyBurnDownId = _data["dailyBurnDownId"];
            this.sprintId = _data["sprintId"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.pointsCompleted = _data["pointsCompleted"];
            this.pointsPending = _data["pointsPending"];
        }
    }

    static fromJS(data: any): DailyBurnDownVm {
        data = typeof data === 'object' ? data : {};
        let result = new DailyBurnDownVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["dailyBurnDownId"] = this.dailyBurnDownId;
        data["sprintId"] = this.sprintId;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["pointsCompleted"] = this.pointsCompleted;
        data["pointsPending"] = this.pointsPending;
        return data; 
    }
}

export interface IDailyBurnDownVm {
    dailyBurnDownId?: number;
    sprintId?: number;
    date?: Date;
    pointsCompleted?: number;
    pointsPending?: number;
}

export class SwaggerException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader(); 
            reader.onload = event => { 
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob); 
        }
    });
}