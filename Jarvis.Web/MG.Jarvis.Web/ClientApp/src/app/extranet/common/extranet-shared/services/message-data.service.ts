import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { MessageListViewModel } from '../../../viewmodel/messageviewmodel/messagelistviewmodel';
import { MessageInfoViewModel } from '../../../viewmodel/messageviewmodel/messageinfoviewmodel';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HotelDataService } from './hotel-data.service';

@Injectable()
export class MessageDataService {
    private _messageData: MessageInfoViewModel;
    get messageDetails(): MessageInfoViewModel {
        return this._messageData;
    }
    set messageDetails(message: MessageInfoViewModel) {
        this._messageData = message;
    }

    constructor(private authenticatedHttpService: AuthenticatedHttpService,
        private portalService: PortalService,
        private activatedRoute: ActivatedRoute,
        private hotelDataService: HotelDataService) { }
    messageListDto: MessageListViewModel[];
    messageInfoDto: MessageInfoViewModel;

    getMessages(hotelId): Observable<MessageListViewModel[]> {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessagesByHotelId', hotelId).map(data => {
                if (data === null) {
                    this.messageListDto = [];
                } else {
                    this.messageListDto = data.result;
                }
                return this.messageListDto;
            });
    }

    getMessageTypes(): Observable<any> {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessageType');
    }

    addMessage(message: MessageInfoViewModel): Observable<number> {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/CreateMessage/', message);
    }

    getMessageDetails(messageId: number): Observable<MessageInfoViewModel> {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessagesByMessageId/', messageId).map(data => {
                this.messageInfoDto = data.result;
                return this.messageInfoDto;
            });
    }

    deleteMessage(messageId: number): Observable<boolean> {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/DeleteMessageByMessageId/', messageId);
    }
}
