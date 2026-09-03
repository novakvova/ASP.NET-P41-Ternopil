import { useMutation, useQueryClient } from "@tanstack/react-query";
import { QrCodeService } from "../services/qrCode.service";
import { RouterEnum } from "../config/RouterEnum";
import { useNavigate } from "react-router";
import type {ICreateQrCode} from "../types/qrCode.types.ts";


export const useQrCodeEditMutation = () => {
    const queryClient = useQueryClient();
    const navigate = useNavigate();

    return useMutation({
        mutationFn: ({
                         id,
                         data,
                     }: {
            id: number;
            data: ICreateQrCode;
        }) =>
            QrCodeService.edit(id, data)
                .then((res) => res.data),
        onSuccess: () => {
            // eslint-disable-next-line @typescript-eslint/no-unused-expressions
            queryClient.invalidateQueries({
                queryKey: ["qrCodes"],
            }),
                navigate(RouterEnum.PROFILE);
        },
    });
};