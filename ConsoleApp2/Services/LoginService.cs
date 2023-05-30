using Google.Protobuf;
using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;
using static Server.Unsorted.Constants;

namespace Server.Services
{
    public class LoginService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(LoginService));

        [Handler(Opcode.PlayerGetTokenCsReq, SessionState.Ignored)]
        public static async Task OnPlayerGetToken(Session connection, byte[] payload)
        {
            var cplrtoken = PlayerGetTokenCsReq.Parser.ParseFrom(payload);
            if (cplrtoken == null) return;

            var a = new PlayerGetTokenScRsp { UID = 1 };
#if DEBUG
            Logger.Debug(cplrtoken.PPIEAKOMAKD);
            Logger.Debug(a.ToString());
#endif
            await connection.SendAsync(Opcode.PlayerGetTokenScRsp, a);
        }

        [Handler(Opcode.PlayerLoginCsReq)]
        public static async Task OnPlayerLogin(Session connection, byte[] _)
        {
            await connection.SendAsync(
                Opcode.PlayerLoginScRsp,
                new PlayerLoginScRsp
                {
                    BGONHENALMD = new BEPIDFNIMLN { NickName = "Hang", Level = 70, HCoin = 10000, SCoin = 10000, WorldLevel = 6 },
                    Stamina = 180,
                    GHFMCFENPNF = "3967187-V1.0Live",
                    RegisterCPS = "hoyoverse_PC",
                    CurServerTimezone = 1,
                    ServerLoginRandomNum = 7235863151202677137,
                    ServerTimestampMs = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds()
                }
            );
            
            //await connection.SendAsync(Opcode.ClientDownloadDataScNotify, new ClientDownloadDataScNotify { IDLEBBNEPGA = new AAIBPJCPOIL {  ByteString = ByteString.FromBase64("G0x1YVMBGZMNChoKBAQICHhWAAAAAAAAAAAAAAAod0ABC0BsdWFjLndyYXAAAAAAAAAAAAABAgUAAAAkAEAAVkAAACAAAAEZAAAAGQCAAAIAAAAEDnNiXzExODQxODA0MzgU/8orAABXORQyUhiKngcQEA4ADABwLlYAAAAAAAAAAAAAKF83QQEAAAAAAAAAAAABOX1FAAAWFgAAa+uBAV/fQEDfX8FA3t9BQ91fwkHc30JG21/DRhPWQwPWVoMDLSwBAG0sQQCtLIEA7SzBAC0vAwFtL0MBrS+DAe0vwwEtLgECVpXAA63uQQLtboECGBwEAG2pxgKtqQcD7alHAy2ohgNtqMYDragBBO2oQQQtq4IEVlACBKTiAkTWUIIEFRKHjKAqBoHsK8IELSoCBVaRwwSmoQcA7apCBS2ljQVtpc0FraUOBu2lTgYtpI8GWFEJAKavCQDtJM8GLScNB20nTQetJ40H7SfNBy0mAwhtJkMIrSaDCO0mwwgtIQUJbSFFCa0hhQntIcUJLSAHCm0gRwqVmA0ZzNiNmrYhjQGhrY2AmZQNABkZgIAUFAAABAI3Hx4eHyUjeiQKER0cHAkSVHc+BwoLGARTaCkTFhMWExdFYSMRBwYTAhcdBgFObC0YHBdScCUXDgUaGw0XYRIBAAAAAAAAFCd+JAoRHRwcCRJUdz4HCgsYBFNoKRMWExYTF0VjLAIdERUdCwsFBR0NWXAlFw4FGhsNF2ERAgAAAAAAAAQYUSQKER0cHAkSVHc+BwoLGARTcCUXDgUaGw0XYRADAAAAAAAABBZfJAoRHRwcCRJUdz4HCgsYBGAXBAAAAAAAAAQUfQQhJzY2T2MsQQJgOBBKPRYFAAAAAAAABCNuJxoRCUR6ewlzPAkSAxYTF0VkIRMTCQMfHQgLGlRwIh0LERYXB2AVBgAAAAAAAAQLVAkCF2dsORQyOw0JADFZAjYeHh4eIxMGBgAAAAAAExMQEAAAAAAABAp9ET1uAAkMBQkIBAUCNwNqDA0AAwxwEwAAAAAAAAABAQAAAQEqKgAAABISAAAUFAAAAQEFAgcAAGRkQECW1kAA5GTAQBUUAQDs7AABbSxAABkZgIADAwAABAp9ET1uAAkMBQkIBAUCNxdcOgEEBQEwIQcXEjQnBhsHCTBTCn0RPW4ACQwFCQgEBwo4AQAAAAAAAAAAAAAAAAAAAAAAAAAAABUVAAAXFwAAAQEEAgYAAFpaAACamoCA1dUAAJBQwAFtLEABGBmAgAAAAAACAgAAAQUFAwIAAAAAAAAAAAAAAAAAAAAAGhoAAB8fAAABAQUIDQAAZGRAQGkpgMBp6UDAaakAwGlpwcGtrQAAbOyAAZzdgcGsLIABnB3BQBQUAQCs7MCBGBmAgAcHAAAEB0AQVwBWAhdDA0QvBQwLGnAWUSwBCA8bHyktCA0DCDIhHQVoFkE7Bxg0LAEIDxsfKS0IDQMIYxBTIhE3LAIdHwELCxo3LAEaEQsacBZBNhE3NgYHGwIEEx8BMDEdDHYCAAAAAAEFBQEAAAAbGwAAHR0AAAEBAwcEAABaWgAAmpqAgGwsQAEYGYCAAAAAAAICAAAAAQABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAiIgAAJiYAAAEBBAwIAABkZEBAlZUAAGzsgAGl5ABA1dWAgKwsgAGYmQABGBmAgAICAAAECn0RPW4ACQwFCQgEBwUyCn0RPW4ACQwFCQgEBAMyAQAAAAAAAAAAAAAAAAAAAAAAAAAAACgoAAAqKgAAAQEDEhEAAGRkQECVlQAAbOyAARNSgMAR0cGBz08AAFMTQIGQUUGB5KSAQJWVAABs7IABU1LBwRERAIDYGEAAWFiAgFlZAAEYGYCABQUAAAQBcQ0JFWECchUDDgl2EwAAAAAAAAAEAWsLHQx0AQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAsLAAAMzMAAAEBDBYaAABrawAApKRAQNXVAACsrAEAEBECgmSlAUDpaEHDFheCgGSmgkBpa8PFktRDAdXXAgNvboKB7a1BAKcngAAhIPyC6RaBAeSkAEDpKQHAFBSBgFZXAwLsbACBF1dDApCQAQCYmQABGBmAgAoKAAAEAnYRCBsBdwJyFQMOCWEDbgcdFhcGcAN0BwYbBwljA2EJHR8MFXABJwdWUSYGWV8DZAwBDQIVcAYuKAZfXAEAAAAAAAAAAAAAAAAAAAAAAAAAAAA1NQAAQkIAAAEBDiMtAABrawAApKRAQNXVAACsrAEAENHGhlrbgYAVFwID722BAe/vAQAREQODZKUBQOloQcMWF4KAZKaCQGlrw8WS1EMB1deCghgZAwFUVgMDLy8DAW1uAgDsrUEAEVFCgmSlAUDpaEHDFheCgGSmgkBpa8PFkhSDAdXXgoIXFgMDb24CAu6tQQCnJ4AAIWC5h+lWwQHkpABA6enCwxQUgYBWF0MC7GwAgReXgwJQUAEAWFkAARgZgIALCwAABAJ2EQgbAXcCchUDDglhA24HHRYXBnADdAcGGwcJYwNhCR0fDBVwDCoHVlEYH1Z3DigHVlEYGAdWUSYGeX8DZAwBDQIVcAYuKAZ/fgMAAAAAAQkJCAkAAAAAAAAAAAAAAAAAAAAAREQAAE1NAAABAQgZEQAAZGRAQJWVAABs7IABUxKAwBFRQIDW1oAAWVkAAVfWgACkZIBA1dUAAKysAQAQEQCAwEDBwacngAAhIP6AJlkAARgZgIAFBQAABAFxDQkVYQJyFQMOCXYTAAAAAAAAAAQCdhEIGwFgEgEAAAAAAAABAQAAAAAAAAAAAAAAAAAAAAAAAAAAAE9PAABeXgAAAgIMGxcAAKSkQECp6QBBxEVAwKwsgAHq6wAAKyoBAFaXwQCkpUBB1dQBAKytAAAQUUGBlJQAghNRQIBfXwKGFREAgJ+eA4ZEgQHCpSaBACHjP4LqlIGB1NQBApuYgYEYGYCABQUAAAQBaAwVHGwCYAoDAB1hEQIAAAAAAAATEgEAAAAAAAAEAnYRCBsBcgEAAAAAAAAAAAAAAAAAAAAAAAAAAABiYgAAdnYAAAICCTozAACamgAA1dWAgKwsgAHOzwABGxuBgBPTwAITUUaGWtoAARQUgYDsbIABEtPAgJFRQ4OaG4GBVFSBgJWUgYEt7UGBm5sBAtfUAQAVFwICru3BgZubAQLX1AEAFReCgq7twYEYGYCAEZGBgaRlgcIrqMFCV1QBAZeXAQDa24GALK2BApeVAALmJADC6+nBwOipgcDoaUHA6CkBwOjpwsMTUoLDEBEAgJkZgIAdnEPDm5sBA9bUAQGtLYEB29sBAxYXAgDs7QEBLW1BABkZgIALCwAAExIBAAAAAAAABAN0BwYbBwljAHcGF2YHQBBXAFYCF0MDRC8FDAsacA9MKwMNAw06NxMBdxRjLBIiCxEZCSgsDw8GAhd2CkI5FCUlFRUsIgsRGQllBAhfNgsKKDkUJSUVFWYHAAABCwsMDAoKDQ0PDgABBgcAAAAAAAAAAAAAAAAAAAAAeXkAAHt7AAABAQMEBwAAZGRAQGkpgMBp6UDAlZUAAGBgAAFYWQAAGRmAgAMDAAAEB0AQVwhDDAUPGRsMBQALBksIRAkHAQQMHxwACQNHAQAAAAAAAAAAAAAAAAAAAAAAAAAAAH9/AACFhQAAAAACDgwAABoaAAAubkAAEdHBgaQkwMBWFkAALGxAASUkwMBW1oAALGxAARkYgIAoKAAAGRmAgAMDAAAECFMxGiA1Aw4JIiIRcBUgAAJ3cnJ0cXEJCQUFBQUIPBUgAAJ3cnJ0cXEJCQUFBQUJOwIAAAEREAAAAAAAAAAAAAAAAAAAAAAAAIiIAACUlAAAAgIMFhoAAKSkQEDWlkAAFRQBAKwsAIHl5EBAFpeBAFVUAQGUlIGA7GyAAhDSAMEQ0cKCmhuBgFZXAAGrqgEB1NQBABUXgoBkJgNBaetDxZJUwwHV1wIBbW6CgZraQQAsbcGBLCwBABkYAQEYGYCACAgAAAQKfRE9bgAJDAUJCAQFAjcJQSMOBSglCxATEws4RQtIIhEkIh0MIiUAFhcWAGATAAAAAAAAAAQCNwgJAAA0A3QHBhsHCWMDYQkdHwwVcBZ/AgsRGQlFQgMSFl8aEEhdXXoCAAAAAAEPDwEAAACPjwAAkZEAAAABAgUGAAAkJEBAWlqAgKWlAAAgIAAAGRkAABkZgIABAQAABAp9ET1uAAkMBQkIBAUCMQIAAAAAAQIDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAJaWAACmpgAAAAAGKy0AACsrAABWVgAAmpoAANXVgIAWV0EArCwAgR6fAAAamgAA1dWAgBaXgQCsLACBHp+AgRuaAADV1YCAFtfBAKwsAIEenwABG5oAANXVgIAWFwABrCwAgR6fgIIYmgAA1dWAgBZXQAGsLACBHp8AAhiaAADV1YCAFpeAAawsAIEen4CDFVbBAdraAAAVFAEBV1cDAuxsAIEe38CEXtoAABUUAQFXF0MC7GwAgR7fQASdGQABGBmAgAoKAAAED34GFhdBARxKCABoDk0iESM+BwoLGHMJSiIRIDsfJz4HCgsYcwtIIhEjPgcKCxgjMR0MI1MKSSIRNy8NEgA9LwwIMlMdXiIRIz4HCgsYIzwaFwQFNCIdDAYWADotYBZVIhEjPgcKCxg7IwEJNyQGM0UJZg4XHAsJXwEcSggAaBdUIhE5IgsRGQktKQ8KCAkgPS9TF1QiETkiCxEZCSMvBQkrLwwIMlYBAAABExIAAAAAAAAAAAAAAAAAAAAAqakAAKurAAAAAAILCQAAJCRAQClpAEApqcBAKemAQCkpQUEdXQFBICAAARgZAAAZGYCABgYAAAQHQBBXAFYCF0MDRC8FDAsacA9MKwMNAw06NxMBdxdgLBgmDAg1OAkSFigsDw8GAhd2Ckc6NCYMCCYsARoRHQx1AQAAAAAAAAAAAAAAAAAAAAAAAAAAAK2tAACysgAAAgIFCA0AAJqaAACsLACArq4AABHRwYEkpMDAqekAQagpwEGoaYBBqKlBQNTVAAAVFIGArOzAgRgZgIAFBQAABAdAEFcAVgIXQwNELwUMCxpwC0wsHR0aAR0HCzAhHQUfdxdaJxgZBA4kJxIRFyE2BgwBChdxAgAAARUUAAAAAAAAAAAAAAAAAAAAAAAAs7MAALy8AAACAgocFgAAEhLAwBERAIDWFkAAq6sAAORkwEDpKQDBFBQBAFZXAAGVlIGA1pdAAVCRQIPu7IGAEBEBgWRlwEHpKADCFhcCAVRXAgPvrcGB5qdAAGFg/4HmmQABGBmAgAgIAAAABAcmVncDdAcGGwcJYwNgCgwVFwtsACxzBVoAWXYCLQJyFQMOCWEDbgcdFhcGdQEAAAAAAAAAAAAAAAAAAAAAAAAAAAC+vgAAz88AAAICBxscAACkpEBA1dUAAKwsgAFTEgBBEBEEhGRkwEAVFAEB7WyAAVMSgMEQUUCAktIAwRARAICZGYCAGhuBgFVUgYGXlwABLK0BgVRUgYCVlAECbi1BARgZgIAREQGBbe0AABobgYFXF0ABlZSBgS1twYEYGYCABgYAAAQKfRE9bgAJDAUJCAQEBzcECn0RPW4ACQwFCQgEBgUzBQUGfm8SAQAAAAAAAAQEAAAAAAEXFxYWFBQBAAAAysoAAMzMAAAAAAMGBQAAGhoAAFpagICamgABLWzAgRgZgIAAAAAAAwMAAAACAwEBAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA0dEAAPf3AAAAAAcLDAAAKysAAFZWAACW1kAA5GTAQBbXwQBWVwAB7GwAgRsbgYBVVIGBrKwBACxtwYEYGYCABQUAAAQQd1lmKx4HCgsYBC8vCgoHEQheATYQd1lmKx4HCgsYBC8vCgoEGBhBAjAKfRE9bgAJDAUJCAQGBzEKfRE9bgAJDAUJCAQGBjAFAgMAAAAAARYWDw8BAAAA1tYAAPb2AAABAQ9JRgAAZGRAQGkpgMBp6UDAaakAwBISwcEREQCAmRmAgKurAADWlkEBJKXAQVVUAQAsLQAAEBELi9JSQUUVkYqK3Z+DRWjuggGcn8DGHhmDgFYVQQKYm4OArC4CglASAkcUUUiIHZ/Axh4ZAwFXFUECmJuDgKwuAoJQEgJHFJGGhikrQMLV1wIEqC6CAeVmAIMTEsHEFBEFhWIigkfYH4NE6W6CAVNSw8YU0cCA0hKDxhRRQICSkkPGFFFBgaTngEMpKkdCU1YDAZSWAwQob8OBEBEBgaTngEMpKkdCU1YDAZSWAwUpb8OBwYCCwyamgQChoPWLW2UFRFVUAQEtrYEBU1JBQxPRwICaGwECVNeFBJWUAQEtbcGBGBmAgBMTAAAEB0AQVwNUKgoHEQhpB0oGSwFVMRUcaBMTAAAAAAAAAAQCdhEIGwF3AmoDGBIXdgFjDwcKdxIBAAAAAAAABAhLIhEyLwUJKy8MCGQABQ5pEAEBAF1LHR1hCH8FFQsHHAdaSx0dYQ5mHxISAF1LHR1hAnIVAw4JYQNuBx0WFwZwAWsLHQxwAjcBAAACNwUAAAAAAQAAAwMBAAICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPz8AAD//wAAAQEGCQ8AAGRkQECW1kAA1dUAAA8OAQBaW4GAbOwAgpeVgIDkZMBAGhuBgOxsgAHvrkAAEREAgFYWwACZmYCBGBmAgAQEAAAECn0RPW4ACQwFCQgEBQI3FGEGABIXFBUXBQUXEgcHB2IKfRE9bgAJDAUJCAQGBTMFAwIAAAAAARsaAAAAAAAAAAAAAAAAAAAAAAIDAQANDAEAAgIHFxAAAKSkQEDV1QAArCyAAVMSAEEQEQGBVdWAgBUUAQHtrEABGBmAgBERAYFt7QAAGhsBAVfXgQCVlIGBLW3BgRgZgIADAwAABAp9ET1uAAkMBQkIBAQHNxMSAQAAAAAAAAMDAAAAAAEdHRQUAQAAAAgJAQAKCwEAAAADBgUAABoaAABaWoCAmpoAAS1swIEYGYCAAAAAAAMDAAAAAQABAQABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABARAQAjIgEAAAAHFxAAABYWAABkJABAlhaAANXVAABs7ACBpWSAQNbWAQEWV0ABVVSBgJWUAQCsLACC2NqAgBUUAQFsbAEA7KzAgRgZgIAGBgAAEzsoAAAAAAAABAp9ET1uAAkMBQkIBAUCNwNqDA0AAwxnCn0RPW4ACQwFCQgEBgcxC2ccEw8AAh8BQAAHQBIAchMAAAAAAAAABgYAAAAAAR0dHBwCAh8fDw8BAAAAFBUBACIjAQABAQgXHwAAZGRAQJqagIDV1QAAbOwAgaXkAEDWVoAAGhuBgKzswIGbmgABE5IAgBERAICZGYCAaGgAAaVkgECsLACA5ORBQempgcAXl4ABVVSBgKRlgEHV1AEBrS2BAdvbgYHtbACC6ugAAhgbgYJUVwMCq+pBAJ9eQQSobcGBGBmAgAoKAAAECn0RPW4ACQwFCQgEBAg8Cn0RPW4ACQwFCQgEBQI3AWMUFwBhCn0RPW4ACQwFCQgEBQUwA3QHBhsHCWMDYQkdHwwVcA0sVl4IVl4IVncNfRscBwYbBwljAjcBAAADNwB3BhhrBgAAAAABAAECAgMDBAQFBQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAlJAEALSwBAAUFCxccAABkZUFAaSiBwmvoQcJrqAHCa2jAw5eUAQDV1AEBFBcCAm7tgQKf3IDDri2BAdxcwELvbYEBU5IBwhLRwoJp6ENBHl+AwYyNgoCAAsBHKa4CgdTUAQQg5oBCKStBR1FXgoGUl4KDL27CgRDRO4RmGYCADQ0AAAQHQBBXA1QqCgcRCGkHSgZLDk4tGxcGFxsdC30NTiIRMi8FCRZ3CkkiETErGxgIFxMVGx12DUQiGRMrKx0MdQEEDEs2BwAXCxpwAHcGF3ERAgAAAAAAAAQCchUDDglhA24HHRYXBnUBAAAAAAAAAAAAAAAAAAAAAAAAAAAALy4BADU0AQAEBAsvJAAA7u4AABGRgYGkJUFAKWgBQiuowUIr6IFCKyhAQyxvQQAREQGBpCVBQCloAUIrqMFCK+iBQitoAENYW4GAlZQBANXUgYAWlIMBVVcCAZSXAgJuLUEDWVuBgJWUAQDV1IGAFtTDAVVXAgGUlwICbi1BA1lbgYCVlAEA1dSBgBYUAAJVVwIBlJcCAm4tQQMaGYCACQkAAAQHQBBXA1QqCgcRCGkHSgZLCV42BBMRCyc/BB0GAWoLTi0AKC0bFwYXGx0bDBZ3FUU7HzQtGxcGFxsdCzYhAhV9AiwESggAaAIsBEsdHWECLARdCgpxAgAAAAABISAAAAAAAAAAAAAAAAAAAAAANzYBAFVUAQAAAA9XWAAAJCRAQClpAEApqcBAKemAQCkpQUFkZEBAaSmBwWnpQcFpqQHBLKyAAWVkQEBpKYDAaelAwGlpwsJpKYLClZUAAGzsgAGqqwAA6+sAABobgYBVVAEAlZQBANXUAQEZGgIALG3BghSXgwJpqAPCQUDCwZSXAgMqKwKDqetDgWRmQkBpK4LEbetCxG2rAsRtK4HHkZcCBGjuggGlJsFDqWuBRtDXgoEUFoOEqO7CgR9fvYNbJUVEVVSBgS2tgQFTEgRGE9HAgJobAQFX14UElZSBgS1twYEXl4MCaagDwkFAwsGUlwIDKquFhKnrQ4FkZkJAaSuCxG3rQsRtqwLEbSuBx5GXAgRo7oIBU5IEwBURAoKSEsXBFREAgJFRQYEamIKA1dcCBBEWAwBVVgMBmZuDgKzuwoIc3zuFWyVFRFVUAQEtrYEBUxIERhPRwICaGwEBVxdEBZWUAQEtbcGBGBmAgBYWAAAEB0AQVwNUKgoHEQhpB0oGSwFVMRUcbBVWIhEwLRsXBhcbHQs3LwwIYQhZOwcdDTwrCQ4HC2EITTEAHAUKAhUdBgFqDW0FFRUxMRUcbA5OLRsXBhcbHQt9C0giETAtGxcGFxsdGwwWYBMAAAAAAAAABANLKQsJExx7EgEAAAAAAAAECEsiETIvBQkrLwwIYQJyFQMOCWEDbgcdFhcGcAFrCx0MdAQCNwEAAAQwCW8OAw09LAcbHRMGAmENThcFFiICCw1hAjcBAAAFNgMAAAAAASAgDw4AAAAAAAAAAAAAAAAAAAAAWFkBAFtaAQABAQYPCQAAXV1AQNaWQABs7ACBnB3AQBbXwQBBgAHAoKAAApuZAAAZGYCABAQAAAQBYw8HCmAIVwdzcgYFAnNydw4gAHcGF3ESAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAF1cAQBragEAAwMHEBcAAOvrAAAaGwEAVVQBACytgQEvLwEAEVFAgFXVAAAREQGBpCXBwCloAUJXVIGBlJQBACxtwYETkkDAEVFBgaQlwcApaAFCV1QBAZSUgYEtbcGBEBEAgB9fQIAZGYCAAwMAAAQCchUDDglhA24HHRYXBnQCAgAAAQkIAAAAAAAAAAAAAAAAAAAAAAAAcHEBAJuaAQAAABR3YwAAFhYAAGQkAEBs7ACAmpqAgBKSwEEQ0cWFJGSAQNXVgICsrAEAEFFEhGTlQEEVFwID722BARxfg8KMjYKDggPDRCmuAoEc34NFKK6CARMSQkYVkYGBmhgCAVRXgoMvroIBHN+DRSiuggEpKoKAEVFAgCcngAAh4DuF1KsAAOvrAAArKgEAa2oBAKuqAQDr6gEAJOaCQFVXgoAsLgMAENHMjORnQkGVlgMGau+DAZxeAseqL4MB3J4BRVJRBACWEoYC2NyEgOxvA4IQkkLFFhECgmQngULp6sDEEhGEgl8ZhcfJywQAwISHymVohIHtr0MAEZGHh12eAUVdXoSAlhKGAtjchIDsbwOCEJJCxRaRg4NdnoLHXF6EgE9LhIhIBIfL5G8DgSjtR4ITksBIGdHDg19fQ8Qj4IZCKS1HS11RBAOWkYSHK2jEgRARAoJpqkABEJJAxxZRQYGfnkLF4ieBQunqwMQSEYSDVlGEhuqvw4EmpYIAoeOwjWoXgoJXVwIDlpeCgxobAgIbGYCADw8AAAQQd1lmKx4HCgsYBC8vCgoHEQheATYKfRE9bgAJDAUJCAQGAzEEA24ZEQgbAXcKfRE9bgAJDAUJCAQABDQAdwYXcRADAAAAAAAABAJqAxgSF3YBK0sdHWEBYw8HCncSAQAAAAAAAAQCchUDDglhA24HHRYXBmcRAgAAAAAAAAEAAgMAAAAAAScnIiMAAAAAAAAAAAAAAAAAAAAAnZwBAK+uAQAAAAg5MQAAGhoAACwsgYHk5MDAFRSBgOxsgAETUoDBEFFBgWTkwMAVFAEB7WyAARNSgMEQEQCAmRmAgOvrAAAkJcHAVVSBgCytgQFTEgBCExEBgZobAQFUVIGAlheBANXUgYEtbUECJiXBwFVUAQEtrYEBUxIAQhMRAYGaGwEBVFQBAZdXwQDV1IGBLW1BAhgbgYETEkFDE5GBgZobAQFbWwEClNdAAdXUgYEtbUECGhmBgCgpgYEbG4GCVNeAAZWUgYEtbcGBGBmAgAcHAAAEAWsLHQx0ExECAAAAAAAAExADAAAAAAAAAQETEgEAAAAAAAAEAjcBAAAGMAYAAAEmJwABJSUkJCcnDw4AAAAAAAAAAAAAAAAAAAAAsbABALOyAQABAQQCBgAAZGRAQJbWQADV1QAAYGCAgVhZAAAZGYCAAgIAAAQKfRE9bgAJDAUJCAQFAjcUcxUUCgEGHgYSFxsGCwIJbgEAAAAAAAAAAAAAAAAAAAAAAAAAAAC1tAEAu7oBAAEBBRQRAABkZEBAltZAANXVAAAaG4GAbOyAAhCSQMARUUCAFlbAAJmZAAGlpEFB2tqAgKwsgAGv7kAAEREAgBZWwACZmQABGBmAgAUFAAAECn0RPW4ACQwFCQgEBQI3FHMbAhABAg8HEhYMAwUEDXUTAAAAAAAAAAQFBQp9ET1uAAkMBQkIBAYFNQIAAAAAARsaAAAAAAAAAAAAAAAAAAAAAL28AQDKywEAAAAJLicAACQkQEBWFkAALKyAAVtagICVlQAAbOyAAROSQMARkYGBGpoAAdcWwAArKoGAVlcAARtawYCs7MCBEJGFhRqagIHU1YCArCyAAdvaAAEXV0ABa6rBAKRlgEGpqENB1ZdDAhUXgoCsLQGBXt6AgidlgEGpqENB1RfDAhUXAgGtLQGBXt6AhB+bAQLX1AEBrS2BAV7egIdqrMCBGBmAgA0NAAAECn0RPW4ACQwFCQgEBQI3EFMiETc2BwAXCxokIh0MBhYAOi13EwAAAAAAAAAEAjcICQABNRR3AhFUUAAZDURGBwgFCQFgAjcBAAAHMwZrbQN0BwYbBwljA2EJHR8MFXAHJkFgBnJ0ByZWdwZvaAUAAAAAASgoDw8rKw4PAAAAAAAAAAAAAAAAAAAAAM7PAQDR0AEAAQEGCQ8AAGRkQECW1kAA1dUAAA8OAQBaW4GAbOwAgpeVgIDkZMBAGhuBgOxsgAHvrkAAEREAgFYWwACZmYCBGBmAgAQEAAAECn0RPW4ACQwFCQgEBQI3FGEGABIXFBUXBQUXEgcHB2IKfRE9bgAJDAUJCAQGBTMFAwIAAAAAARsaAAAAAAAAAAAAAAAAAAAAANLTAQDU1QEAAQEEAgYAAFZWAABdHYDA1dUAAGBggIFYWQAAGRmAgAICAAAEATVIXV18A2EJHR8MFXQAAAAAAAAAAAAAAAAAAAAAAAAAANXUAQDh4AEAAAAQPi4AACsrAABkZEBApOQAQKysgIBsbAEBEVFHhxqbgYDV1IGCrm3BARKTgYCQEQaGpOaCQFVXgoIuroIBVFQBBCAmQ0EpawNFUVcCAKSmQ0GpK8NE7umCgRQWg4JUlcIBmpkDAdTWAwOvL4MBUdMAhZCVAQLjoMODEhEAgFaVQQKQU8AE3JnCgReVgQKsroKBLW5CAGfngADhITeIME8AABNTQIGQ0cCA2lqAgZdWwgLV1QAAbCzAgRgZgIAMDAAABANuGREIGwF3Cn0RPW4ACQwFCQgEBgMiEwAAAAAAAAAECn0RPW4ACQwFCQgEAAQ0AnIVAw4JYQNuBx0WFwZwA2QMAQ0CFXACZQwLAV8+AnUaDglUPgUFBjk/AjcBAAAIPAQAAAAAAS0tLCwPDgAAAAAAAAAAAAAAAAAAAADk5QEA7ewBAAAABA0JAAAkJEBAKWkAQCmpwEAp6YBAWlqAgJaWAQHt7QAAbCzAgRgZgIAFBQAABAdAEFcDVCoKBxEIaQ1NJRURMT0ECGEASiEYZAcUAAAAAAAAAwMAAAAAARQUDw8BAAAA5ucBAOztAQAAAAgfFwAAJCRAQClpAEApqcBAKemAQFpagIBBAUAAaWnBwW4uQAAREQCA1hZBAROTQcERUUKCGpoAAdcWwQErKgEAZGVDQmkog8CUF4MC1dSBgGxtgYEaWkEArOzAgRgZgIALCwAABAdAEFcDVCoKBxEIaQ1NJRURMT0ECGEASiEYcxZGOxsVDSEkBQAFGhYGDAEKF3ADAAAAAAAAABMrckoAAAAAAAQCNwEAAAczA3QHBhsHCWMDYQkdHwwVcAcmQmQDAAAAAAEBAAICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAO/uAQDx8AEAAAAEAwcAABoaAABWVgAAq6uAgNaWQACb28CALGzAgRgZgIACAgAABAI3CAAAAD0VXTkUEhsNCQBMZi8HBxobRi8BAAABDw4AAAAAAAAAAAAAAAAAAAAA9PUBAAQGAgABAQUKDwAAZGRAQJWVAABs7IABUxKAwBHRwIDkZEBAlZUAAGBgAAFYWQAAXd3AQNYWwAAtLAEAYGAAAltZAAAZGYCABAQAAAQBcQ0JFWEDdAcGGwcJYwFiFAYXZgYsLwEAAAAAAQEAAAD4+QEAAwECAAEBAgwOAAASEkBAEVFAgNYWQABZWQABE5LAQBFRQIDWlsAAWVkAARMSQUERUUCA1hZBAVlZAAEYGQABGBmAgAYGAAAEBiAmB19+JgZeWAdfAFgGCA4HXzJuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGBAIAFRcCAAEBAwcEAABWVgAAra0AAJmZAAEYGYCAAQEAAAQHLgApBAAAAAABJSUwMA8PAQAAAAgKAgAUFgIAAAEIIyoAACsrAABkZEBAmpqAgGzsgAFTEoDAEZGCgtpaAAGXFoAA1hbAACQlQUBaW4GALK2BAZGQAQDX1gEBFRQBAGwsQAIT0cSE5CQBQZqagIDkZMFB6SkBwCQkAQBsrMAAbm4AABERAIAZmQAB29oAARcXAwJaW4GBl9dDAtrbAQIXFwIB7W2BARHRwANU14MClZQBAOysQAJYWoCClFbCAtXVAABsLMCBGBmAgAwMAAAEAXENCRVhDW8TGw0XHQYBaghXPhcASE0FExEtfSQIbwFCVA0JFUVJGlMzGQoAAAAAAAAEA38IEwINAGgCYgEHFxJjDn4GEwIGBwMCCG8CXT4XAEg+B159M31uAAAAAAAABAI3CAkAAjQGAAAAAAEBAAEAAAECAgMDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABgaAgAuLAIAAAAQOysAABoaAABWVgAAltZAACysAIFUVQAAlhaAAGzsgAET0gDAEREAgJkZgICra8AAn98Bwx1fgcIc3wLGb+sAACSlQ8JVVAEBLS0AABARBITAQoCCpGYAwtXXgoQSFQADrC4CgVOSgEUUUUKCZKaBw+lrQcYT1cADZCeAw2lqx8KQ1UcE1dYDBWlvg4HtboIA3x9CgSSmgQChoPqEZRsBAVfXhQSVlIGBLW3BgRgZgIATEwAABA1iDhccCwlfATYVViIROSILERkJLSkPCggJJEUVYgcVEwATCAUOAxIWS0oIAH8TAAAAAAAAAAQJQQgWDRMDDgUbGwgAX9MNwg8AAAAABAlOCw0EFQsaCwkOBwtWU9mWDwAAAAAEC0sBBxcSAhcNGwEREQYXR7Nr0BsAAAAABAJ2EQgbAXcKfRE9bgAJDAUJCAQECCsXBAAAAAAAAAQDdAcGGwcJYwNhCR0fDBVwByZdfANyGx4RAghvBktNAjcBAAEBMwMAAAETEgABDw4AAAAAAAAAAAAAAAAAAAAAMDICAEJAAgAAAAwpJQAAKysAAGtrAAGXlgAA1pZAAFsbQAGbmgAA1laAABbXwQCsLACB5eTBwRUUgYDs7AEAEJGCgpUXAgFUV4KDL66CAVMSAUUVUUGB5OZDwWmrA8WSlAAC1dcCBGjuAoEeX8KB5GeAAGHgfYObpILCFRQBAOxsgAETkkLDEBEAgJkZgIDa2gABF9fDAlVUAQDsrMCBGBmAgAwMAAAECn0HFRMtLRMIBUJKCABoFUInFRNffzMIBUFqBG1KCABoDWIOFxwLCV8BNhVWIhE5IgsRGQktKQ8KCAkkRQNuGREIGwFgEwAAAAAAAAAEA3QHBhsHCWMDYQkdHwwVcAcmXXwBawsdDHQEAjcBAAAJOgMAAAETEgABDw4AAAAAAAAAAAAAAAAAAAAAREYCAF5cAgAAAAQvKwAAJCTAwClpAEApqcBAKemAQCkpQUEoKAAAGhoAAS1swIAaGoCBVxZBAavrQADa2gACnV/Ag69swIEbGoCBV5bBAavrQADa2gAAn1/AhKhswIEbGoCCLmzAgBoaAAMvbMCAGhqAgy9swIAaGgAEKGzAgBoagIQobMCAGhoABSlswIAaGoCFKWzAgBoaAAYqbMCAGhqAhipswIAaGgAHK2zAgCsrAAAZGQABGBmAgAkJAAAEB0AQVwBWAhdDDU4mDAgmLB0XYQhaMxcBGgYBKiUVFWUMXjMXARoGAWoCNwEAAAA0AXYFExd2AjcBAAABNQFiERMXfQ8AAAECAwABEBAPDwEBGRkeHiMjKSkqKi8vLi41NTIyMTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACjAQAAAAEAAAAAAAUAAAABAAAAAQAAAAEAAAABAAAAAQAAAAAAAAABAAAABV9FTlY="), Time = 1683395913, Version = 60 } });
            await connection.SendAsync(Opcode.UpdateFeatureSwitchScNotify, new UpdateFeatureSwitchScNotify());
            await connection.SendAsync(Opcode.SyncServerSceneChangeNotify, new SyncServerSceneChangeNotify());
            await connection.SendAsync(Opcode.DailyTaskDataScNotify, new DailyTaskDataScNotify());
            await connection.SendAsync(Opcode.RaidInfoNotify, new RaidInfoNotify());
            await connection.SendAsync(Opcode.BattlePassInfoNotify, new BattlePassInfoNotify { BattlePassData = 1, PurchaseType = BpTierType.Premium2 });
        }
        
        [Handler(Opcode.GetLevelRewardTakenListCsReq)]
        public static async Task OnGetLevelRewardTakenList(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetLevelRewardTakenListScRsp, new GetLevelRewardTakenListScRsp());
        }

        [Handler(Opcode.GetMissionStatusCsReq)]
        public static async Task OnGetMissionStatus(Session session, byte[] payload)
        {
            var getM = GetMissionStatusCsReq.Parser.ParseFrom(payload);
            if (getM == null) return;

            var a = new GetMissionStatusScRsp();
            foreach (var _sub in getM.SubMissions)
            {
                a.SubMissionStatusList.Add(new MissionData { Id = _sub, Status = MissionStatus.MissionFinish });
            }
            foreach (var _event in getM.EventMissions)
            {
                a.MissionEventStatusList.Add(new MissionData { Id = _event, Status = MissionStatus.MissionFinish });
            }
            foreach (var _unfinish in getM.UnFinishedMissions)
            {
                a.FinishedMainMissionIdList.Add(_unfinish);
            }

            await session.SendAsync(Opcode.GetMissionStatusScRsp, a);
        }

        [Handler(Opcode.GetRogueScoreRewardInfoCsReq)]
        public static async Task OnGetRogueScoreRewardInfo(Session session, byte[] _)
        {
            var b = new GetRogueScoreRewardInfoScRsp
            {
                ELBKFCDJPGF = new IMLOGEMOJMI
                {
                    HasTakenInitialScore = true,
                    PoolID = 23,
                    PoolRefreshed = true
                }
            };
            await session.SendAsync(Opcode.GetRogueScoreRewardInfoScRsp, b);
        }

        [Handler(Opcode.GetGachaInfoCsReq)]
        public static async Task OnGetGachaInfo(Session session, byte[] _)
        {
            var gachaInfo = new GetGachaInfoScRsp
            {
                RandomNum = 91
            };

            gachaInfo.MGFPBBAKOMI.Add(new GLIBDFCOMJJ
            {
                GachaID = 2004,
                HistoryURL = "https://google.com",
                EndTimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds() * 2
            });

            gachaInfo.MGFPBBAKOMI[0].EDBGNPCFHBB.AddRange(new uint[] { 1001, 1202, 1204, 1206 }); //4 stars list
            gachaInfo.MGFPBBAKOMI[0].NFGHMBCIJCD.AddRange(new uint[] { 1204 }); //5 stars list

            await session.SendAsync(Opcode.GetGachaInfoScRsp, gachaInfo);
        }

        [Handler(Opcode.QueryProductInfoCsReq)]
        public static async Task OnQueryProductInfo(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.QueryProductInfoScRsp, new QueryProductInfoScRsp());
        }

        [Handler(Opcode.GetQuestDataCsReq)]
        public static async Task OnQuestData(Session session, byte[] _)
        {
            var a = new GetQuestDataScRsp();
            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092335,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204007,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000123,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052338,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052316,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000076,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001793,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071013,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092328,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092327,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000014,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052340,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4032306,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080602,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072016,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071607,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080605,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001762,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052324,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070804,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052309,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071015,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001763,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080606,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072026,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092324,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000013,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001764,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092322,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000120,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092332,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000080,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001797,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000062,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020502,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070705,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052342,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070802,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092341,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070904,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020701,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4042307,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080402,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4042308,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040402,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092345,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7000004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071606,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080604,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001761,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052341,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7099902,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052333,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052343,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001721,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7206001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072017,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070607,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071016,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052310,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001716,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2200004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071506,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070803,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080404,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092340,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052323,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080305,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070602,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070801,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070906,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092315,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070917,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000066,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092352,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092343,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7000002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072012,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4022404,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000073,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052339,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092338,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090207,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052349,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4091003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080304,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071501,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001711,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052321,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070707,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040409,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051108,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052345,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070702,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000112,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000107,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001724,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052328,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001732,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000106,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040602,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000109,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001798,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000115,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001792,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4042301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201008,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001795,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000110,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001752,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000126,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052329,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002007,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092329,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000018,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052330,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002008,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000108,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040604,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000107,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040603,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001799,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000113,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000108,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052331,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002009,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000078,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000077,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000116,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052352,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001796,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000079,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000068,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052308,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052336,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051109,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040410,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072022,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052353,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040412,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051111,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052305,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000069,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000070,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072024,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001767,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000011,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4012301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070608,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000012,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4012302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052315,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070421,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052312,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000074,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070604,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001741,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070708,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000106,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000111,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001753,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000127,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001743,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000117,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7000003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092344,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072013,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071605,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072014,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092351,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000065,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070812,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070403,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7000001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092342,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092325,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040601,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001731,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092312,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070914,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4022403,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000072,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080603,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001727,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020403,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070606,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071601,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070805,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052304,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001742,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070709,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072008,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092323,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000114,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092334,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000122,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204006,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080403,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001725,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070703,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052337,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201007,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7202002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092361,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000075,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071603,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071502,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001712,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4032307,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070913,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090205,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052347,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092319,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070915,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092313,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080601,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052314,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070907,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092326,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001771,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000015,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092318,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052319,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100112,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072020,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4091001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052320,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080501,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052313,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071009,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001784,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092353,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040504,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000067,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071017,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052354,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052311,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000071,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052306,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052325,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030104,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052344,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000207,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071012,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070603,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001722,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092336,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071014,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020402,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070605,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000208,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100117,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071610,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070502,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070911,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000019,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001775,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052326,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001734,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070701,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001723,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7202001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010102,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070902,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001766,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071609,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7206002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072018,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080504,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001726,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070704,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001765,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070611,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071018,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070609,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040403,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072305,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080506,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092346,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000060,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070807,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4030202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204008,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000124,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040702,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092349,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000063,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070401,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070810,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052348,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090206,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090501,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001782,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070610,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070201,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070903,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010501,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071008,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4032305,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052346,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4090204,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001754,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000128,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7201002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070402,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070901,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060202,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7099901,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052332,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040406,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092331,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000119,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052335,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070441,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092337,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204009,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000125,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080101,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001785,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000209,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080505,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001776,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070912,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072027,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000004,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2200005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001717,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072023,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051110,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040411,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092321,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092339,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070909,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001773,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000017,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072019,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7206003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000064,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092350,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040407,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051106,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010105,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071007,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071604,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4082303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4000003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070808,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052334,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040408,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051107,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4022302,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001713,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2200001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070601,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4072103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052351,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020702,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070905,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070612,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070806,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4000001,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4082301,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071602,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052317,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092316,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052327,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1002005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092320,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052318,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092317,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2000002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092330,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092314,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070916,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092333,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000121,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204005,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001715,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2200003,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071505,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070908,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001772,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000016,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040701,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4060402,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010504,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071608,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4032308,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4032309,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052350,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020203,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001783,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070910,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070501,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4051103,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040404,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 6000061,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4092347,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001744,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7203002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7204002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 3000118,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4052307,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070303,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4010502,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4020503,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4070706,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2100124,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4080502,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 2200002,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 1001714,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4071504,
                Status = QuestStatus.QuestClose
            });

            a.OEOJNINIGMB.Add(new FHBEBAPKNKM
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 7205007,
                Status = QuestStatus.QuestClose
            });
            //await session.SendBytesAsync(new byte[] { 0x9d, 0x74, 0xc7, 0x14, 0x03, 0xa5, 0x00, 0x00, 0x00, 0x00, 0x2f, 0x18, 0x70, 0x45, 0x42, 0x0e, 0x40, 0xef, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf0, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf1, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf2, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf3, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf9, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xfb, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x86, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x8e, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc6, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x83, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xfa, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x84, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xfd, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xfc, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa1, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc7, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xfe, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xff, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf4, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x8d, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x98, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x99, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x9a, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa6, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xf5, 0x91, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa3, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa4, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xad, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xab, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xac, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb7, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb9, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa5, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc0, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xaf, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb0, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb6, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc1, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc3, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc4, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa2, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x8f, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x90, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc5, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb8, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xa7, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc9, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xca, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xcb, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xcc, 0x92, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xad, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xae, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xaf, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb0, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb1, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb2, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xb3, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc1, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc2, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc3, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc4, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc5, 0x93, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x91, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x92, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x93, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x94, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x95, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x96, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x97, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x98, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x99, 0x94, 0x3d, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x81, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x82, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x83, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0x84, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xe5, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xe6, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xe7, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xe8, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xe9, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xea, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xeb, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xec, 0x89, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0x58, 0x03, 0x42, 0x0e, 0x40, 0xc9, 0x8a, 0x7a, 0x18, 0x94, 0x97, 0x9d, 0x9f, 0x06, 0x20, 0x01, 0xD7, 0xA1, 0x52, 0xC8 });
            await session.SendAsync(Opcode.GetQuestDataScRsp, a);
        }

        [Handler(Opcode.GetDailyActiveInfoCsReq)]
        public static async Task OnGetDailyActiveInfo(Session session, byte[] _)
        {
            var a = new GetDailyActiveInfoScRsp();
            await session.SendAsync(Opcode.GetDailyActiveInfoScRsp, a);
        }

        //9
        [Handler(Opcode.GetSpringRecoverDataCsReq)]
        public static async Task OnGetSpringRecoverData(Session session, byte[] _)
        {
            var spring = new GetSpringRecoverDataScRsp
            {
                HGPHPJMOIHK = new HCMHCAPMDNO
                {
                    JLLDBGGMCOD = 1000,
                    OJFODJFDBOC = DateTimeOffset.Now.ToUnixTimeSeconds()
                },

                JJPFKBLEJAF = new LCIKOENMNNP
                {
                    IsAutoRecover = true,
                    TotalRecoverPercentage = 10000
                }
            };

            await session.SendAsync(Opcode.GetSpringRecoverDataScRsp, spring);
        }

        //11
        [Handler(Opcode.GetPlayerBoardDataCsReq)]
        public static async Task OnGetPlayerBoardData(Session session, byte[] _)
        {
            var boardRsp = new GetPlayerBoardDataScRsp();
            await session.SendAsync(Opcode.GetPlayerBoardDataScRsp, boardRsp);
        }

        //12
        [Handler(Opcode.GetAvatarDataCsReq)]
        public static async Task OnGetAvatarData(Session session, byte[] _)
        {
            var av = new GetAvatarDataScRsp
            {
                APEAJOEOKGB = true
            };
            av.NLDDFJCAHIA.Add(new MODMGOPBHIM
            {
                BelongAvatarID = 1001,
                FirstMetTimeStamp = 1684660059,
                Level = 1,
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001001
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001002
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001003
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001004
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001007
            });

            av.NLDDFJCAHIA.Add(new MODMGOPBHIM
            {
                BelongAvatarID = 1006,
                FirstMetTimeStamp = 1684660059,
                Level = 80
            });

            await session.SendAsync(Opcode.GetAvatarDataScRsp, av);
        }

        //13
        [Handler(Opcode.GetAllLineupDataCsReq)]
        public static async Task OnGetAllLineupData(Session session, byte[] _)
        {
            var line = new GetAllLineupDataScRsp();
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL[0].NLDDFJCAHIA.Add(new KAFAEJMPIPK
            {
                CharacterAvatarType = AvatarType.AvatarFormalType,
                Id = 1006,
                PEHLPPIINLH = 10000
            });
            line.JKMFKKCEOIL[0].NLDDFJCAHIA.Add(new KAFAEJMPIPK
            {
                Id = 1001,
                PEHLPPIINLH = 10000,
                Slot = 1
            });

            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 1,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 2,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 3,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 4,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 5,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            await session.SendAsync(Opcode.GetAllLineupDataScRsp, line);
        }

        //14
        [Handler(Opcode.GetMissionEventDataCsReq)]
        public static async Task OnGetMissionEventData(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetMissionEventDataScRsp, new GetMissionEventDataScRsp());
        }

        //15
        [Handler(Opcode.GetChallengeCsReq)]
        public static async Task OnGetChallenge(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetChallengeScRsp, new GetChallengeScRsp());
        }

        //16
        [Handler(Opcode.GetRogueInfoCsReq)]
        public static async Task OnGetRogueInfo(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetRogueInfoScRsp, new GetRogueInfoScRsp());
        }

        //17
        [Handler(Opcode.GetExpeditionDataCsReq)]
        public static async Task OnGetExpeditionData(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetExpeditionDataScRsp, new GetExpeditionDataScRsp());
        }

        //18
        [Handler(Opcode.SyncClientResVersionCsReq)]
        public static async Task OnSyncClientResVersion(Session session, byte[] payload)
        {
            var p = SyncClientResVersionCsReq.Parser.ParseFrom(payload);
            if (p == null) return;
            var v = new LNLMFFDHMOE
            {
                NFJLJJFLJKB = p.CMFAFDDBGFA
            };
            await session.SendAsync(Opcode.SyncClientResVersionScRsp, v);
        }

        [Handler(Opcode.GetBagCsReq)]
        public static async Task OnGetBag(Session session, byte[] _)
        {
            var bagRsp = new GetBagScRsp();
            bagRsp.GMPOJOGNPDI.Add(new KFCHDBDIPLK
            {
                MJFFFJOEPKJ = 102,
                Count = 1000000,
            });

            await session.SendAsync(Opcode.GetBagScRsp, bagRsp);
        }

            //await session.SendBytesAsync(new byte[] { 0x9d, 0x74, 0xc7, 0x14, 0x02, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0c, 0x3a, 0x04, 0x28, 0x01, 0x50, 0x14, 0x3a, 0x04, 0x28, 0x66, 0x50, 0x14, 0xd7, 0xa1, 0x52, 0xc8 });

        //19
        [Handler(Opcode.GetLoginActivityCsReq)]
        public static async Task OnGetLoginActivity(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetLoginActivityScRsp, new GetLoginActivityScRsp());
        }

        //20
        [Handler(Opcode.GetRaidInfoCsReq)]
        public static async Task OnGetRaidInfo(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetRaidInfoScRsp, new GetRaidInfoScRsp());
        }

        //21
        [Handler(Opcode.GetCurSceneInfoCsReq)]
        public static async Task OnGetCurSceneInfo(Session session, byte[] _)
        {
            var s = new GetCurSceneInfoScRsp
            {
                SceneInfo = new HCFBMEBDAEG()
            };

            s.SceneInfo.RaidGameMode = 7;
            s.SceneInfo.CPADEJILABD.AddRange(new uint[] { 10, 9, 5, 7, 13 });
            s.SceneInfo.CurMapEntryID = 801120102;
            s.SceneInfo.CurrWorldID = 101;
            s.SceneInfo.FloorID = 80112001;
            s.SceneInfo.HOCBBLHJJNI = 1;
            /*
            s.SceneInfo.IEKMNLCNKIM.Add(new SceneEntityInfo
            {
                Actor = new LDPLDBBEHFP { BelongAvatarID = 1001, CharacterAvatarType = AvatarType.AvatarFormalType },
                EntityId = 1050367,
                Motion = new OEFEOGHDJIO
                {
                    IBFIEOOEPOM = new NPLFPMKFPMD { EDIABGLFJEN = 262000 },
                    ONOEPJLAFJC = new NPLFPMKFPMD { EDIABGLFJEN = 1430, IsPatched = 15998, NNEGNBCLLEN = 3100 }
                }
            });
            */

            s.SceneInfo.JHNMDMEHBII = 1050365;
            s.SceneInfo.PlaneID = 80112;

            await session.SendAsync(Opcode.GetCurSceneInfoScRsp, s);
           // await session.SendAsync(Opcode.GetCurLineupDataScRsp, new GetCurLineupDataScRsp());
           // await session.SendAsync(Opcode.GetCurBattleInfoScRsp, new GetCurBattleInfoScRsp());
        }

        //22
        [Handler(Opcode.GetCurLineupDataCsReq)]
        public static async Task OnGetCurLineupData(Session session, byte[] _)
        {
            var lineupRsp = new GetCurLineupDataScRsp();
            await session.SendAsync(Opcode.GetCurLineupDataScRsp, lineupRsp);
        }

        //23
        [Handler(Opcode.GetCurBattleInfoCsReq)]
        public static async Task OnGetCurBattleInfo(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetCurBattleInfoScRsp, new GetCurBattleInfoScRsp());
        }

        //24
        [Handler(Opcode.GetNpcStatusCsReq)]
        public static async Task OnGetNpcStatus(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetNpcStatusScRsp, new GetNpcStatusScRsp());
        }

        //25
        [Handler(Opcode.GetNpcMessageGroupCsReq)]
        public static async Task OnGetNpcMessageGroup(Session session, byte[] _)
        {
            await session.SendAsync(Opcode.GetNpcMessageGroupScRsp, new GetNpcMessageGroupScRsp());
        }

        //26
        [Handler(Opcode.GetTutorialCsReq)]
        public static async Task OnGetTutorial(Session session, byte[] _)
        {
            var tutorial = new GetTutorialScRsp();
            var tutorialIds = new uint[] {1001, 1002, 1003, 1004, 1005, 1007, 1008, 1010, 2000, 2001, 2002, 2003, 2004, 2008, 2010, 2011, 2012, 2013, 3001, 3002,
            3003, 3004, 3005, 3006, 3008, 3009, 3010, 3011, 3012, 3202, 4002, 4003, 4004, 4005, 4006, 4007, 4008, 4009, 4010, 4011, 4012, 5001, 5002, 5003, 5004,
            5005, 5006, 5007, 5008, 5009, 5010, 5011, 5012, 5013, 5014, 5015, 5016, 5017, 5018, 5019, 5021, 5022, 5023, 5024, 5025, 5026, 5027, 5028, 5029, 5030, 5031, 5032,
            5033, 5034, 5035, 5036, 5039, 5041, 7001, 9001, 9002, 9003, 9004, 9005, 9006, 9007, 9008, 9009, 9010, 9011, 9012, 9013, 9014, 9015, 9016, 9017, 9018, 9019,
            9020, 9021, 9022, 9023, 9024};

            for (int i = 0; i < tutorialIds.Length; i++)
            {
                tutorial.TutorialList.Add(new Tutorial
                {
                    Id = tutorialIds[i],
                    Status = TutorialStatus.TutorialFinish
                });
            }

            //await session.SendAsync(Opcode.GetTutorialScRsp, tutorial);
        }

        //27
        [Handler(Opcode.GetTutorialGuideCsReq)]
        public static async Task OnGetTutorialGuide(Session session, byte[] _)
        {
            var tutorial = new GetTutorialGuideScRsp();
            await session.SendAsync(Opcode.GetTutorialGuideScRsp, tutorial);
        }

        //28
        [Handler(Opcode.UnlockTutorialGuideCsReq)]
        public static async Task OnUnlockTutorialGuide(Session session, byte[] payload)
        {
            var unlockTut = UnlockTutorialGuideCsReq.Parser.ParseFrom(payload);
            if (unlockTut == null) return;

            var b = new UnlockTutorialGuideScRsp
            {
                TutorialGuide = new TutorialGuide()
            };
            b.TutorialGuide.Status = TutorialStatus.TutorialFinish;
            b.TutorialGuide.Id = unlockTut.GroupID;
            await session.SendAsync(Opcode.UnlockTutorialGuideScRsp, b);
        }

        //29
        [Handler(Opcode.FinishTutorialGuideCsReq)]
        public static async Task OnFinishTutorialGuide(Session session, byte[] payload)
        {
            var finishTutGuide = FinishTutorialGuideCsReq.Parser.ParseFrom(payload);
            if (finishTutGuide == null) return;

            var _b = new FinishTutorialGuideScRsp
            {
                Reward = new ItemList(),
                TutorialGuide = new TutorialGuide()
            };

            _b.TutorialGuide.Id = finishTutGuide.GroupID;
            _b.TutorialGuide.Status = TutorialStatus.TutorialFinish;
            _b.Reward.ItemList_.Add(new Item { ItemId = 1, Num = 1 });
            await session.SendAsync(Opcode.FinishTutorialGuideScRsp, _b);
        }

        [Handler(Opcode.PlayerHeartbeatCsReq)]
        public static async Task OnPlayerHeartbeat(Session session, byte[] payload)
        {
            await session.SendAsync(Opcode.PlayerHeartbeatScRsp, new LNLHNPDBEAD());
        }

        [Handler(Opcode.DoGachaReq)]
        public static async Task OnDoGacha(Session session, byte[] payload)
        {
            var doGachaReq = DoGachaCsReq.Parser.ParseFrom(payload);
            if (doGachaReq == null) return;
            var doGacha = new DoGachaScRsp
            {
                GachaID = doGachaReq.GachaID,
                MAADKKIJJOC = doGachaReq.RandomNum,
                Num = doGachaReq.Num
            };

            var chars = new uint[] { 1005, 1006, 1009, 1013, 1101, 1102, 1104, 1206, 1001, 1203 };
            for (int i = 0; i < chars.Length; i++)
            {
                doGacha.MJDNKCHNADE.Add(new GKIGHAFBNBO
                {
                    ItemId = new Item { ItemId = chars[i], Num = 1 },
                    ItemList = new ItemList(),
                    ItemList12 = new ItemList()
                });
            }

            await session.SendAsync(Opcode.DoGachaScRsp, doGacha);
        }
    }
}