CREATE PROCEDURE [dbo].[ESP_Boards_Action]
(
    @BoardSeq              bigint
    ,@MemberSeq             bigint
    ,@Column                varchar(50)
    ,@Code					bigint				output
    ,@Value					varchar(100)		output
    ,@Msg					nvarchar(100)	    output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRAN

BEGIN TRY
IF NOT Exists(select MemberSeq from Members where MemberSeq = @MemberSeq)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상 회원이 없습니다.'
	END
ELSE IF NOT Exists(select BoardSeq from Boards where BoardSeq = @BoardSeq)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상 게시판이 없습니다.'
	END
ELSE
    BEGIN
        IF Exists(Select BoardSeq From BoardActionLog where BoardSeq = @BoardSeq and MemberSeq = @MemberSeq and [Column] = @Column)
            BEGIN
                SET @Err = @Err + 1
                
                IF @Column = 'LikeCount'
                    BEGIN
                       SET @Msg = '이미 좋아요 하셨습니다.' 
                    END
                ELSE IF @Column = 'UnLikeCount'
                    BEGIN
                       SET @Msg = '이미 싫어요 하셨습니다.' 
                    END
                ELSE IF @Column = 'RecommendCount'
                    BEGIN
                       SET @Msg = '이미 추천 하셨습니다.' 
                    END
                ELSE
                    BEGIN
                        SET @Msg = '이미 참여하였습니다.' 
                    END
            END
        ELSE
            BEGIN
                Insert into BoardActionLog (MemberSeq, BoardSeq, [Column]) values (@MemberSeq, @BoardSeq, @Code)

                SET @Err = @Err + @@Error
                SET @Code = @BoardSeq
            END
    END


END TRY
BEGIN CATCH
    SET @Err = @Err + 1
    SET @Msg = ERROR_MESSAGE()
END CATCH

IF @Err > 0
    BEGIN
        ROLLBACK TRAN
        SET @Code = -1
        IF @Msg = ''
            SET @Msg = '데이터베이스 처리가 실패하였습니다.'
    END
ELSE
    BEGIN
        COMMIT TRAN
    END