import instance from "./api/interceptors.api.ts";
import {getQrCodesUrl} from "../config/api.config.ts";
import type {ICreateQrCode, IQrCode} from "../types/qrCode.types.ts";

export const QrCodeService = {
    getAll: () => instance.get<IQrCode[]>(getQrCodesUrl()),
    post: ({ data }: { data: ICreateQrCode }) =>
        instance<void>({
            url: getQrCodesUrl(),
            method: "POST",
            data,
        }),
    
    delete: (id: number) =>
        instance<void>({
            url: `${getQrCodesUrl()}/${id}`,
            method: "DELETE",
        }),

    edit: (id: number, data: ICreateQrCode) =>
        instance<void>({
            url: `${getQrCodesUrl()}/${id}`,
            method: "PUT",
            data,
        })
};