	.intel_syntax noprefix
	.text
	.globl	shimonize

# ｼﾓﾅｲｽﾞ
# 0. 入力文字列
# 1. 出力ﾊﾞｯﾌｧー
# 2. 出力ﾊﾞｯﾌｧーｻｲｽﾞ
shimonize:
    # 初期化
	push	rbx
    # 限界値をﾊﾞｯﾌｧーｻｲｽﾞ数-1にしとく
	dec	    edx
	xor	    eax, eax # ﾙーﾌﾟｶｳﾝﾀー

# ｿーｽのｹﾂまで回す
.CVT_LOOP:
	cmp	    eax, edx
	mov	    cl, BYTE PTR [rdi]

    # 限界値超えたのでﾍﾞｲﾙｱｳﾄ
	jge	    .BAILOUT

    # ｹﾂまで行ったので終了
	test	cl, cl
	je	    .END_CVT

    # UTF-8ﾊﾞｲﾄ数計算
	mov	    r8b, cl
	xor	    r9d, r9d
	and	    r8d, 0xffffffc0
	cmp	    r8b, 0xffffffc0
	mov	    r8b, cl
	sete	r9b
	and	    r8d, 0xffffffe0
	cmp	    r8b, 0xffffffe0
	sete	r8b
	movzx	r8d, r8b
	add	    r8d, r9d
	mov	    r9b, cl
	and	    r9d, 0xfffffff0
	cmp	    r9b, 0xfffffff0
	sete	r9b
	movzx	r9d, r9b
	add	    r9d, r8d
	mov	    r8b, cl
	and	    r8d, 0xfffffff8
	cmp	    r8b, 0xfffffff8
	sete	r8b
	movzx	r8d, r8b
	add	    r8d, r9d
	mov	    r9b, cl
	and	    r9d, 0xfffffffc
	cmp	    r9b, 0xfffffffc
	sete	r9b

    # 先頭E3じゃなければｽｷｯﾌﾟ
	cmp	cl, 0xffffffe3
	movzx	r9d, r9b
	lea	    r8d, [r8+1+r9]
	jne	    .SKIP_CHAR

    # 3byteじゃなければｽｷｯﾌﾟ
	cmp	    r8d, 3
	jne	    .SKIP_CHAR

	mov	    r11b, BYTE PTR [rdi+1]
	xor	    ecx, ecx
    # 82じゃなければｽｷｯﾌﾟ
	lea	    r9d, [r11+126]
	cmp	    r9b, 1
	ja	    .SKIP_CHAR_L

    # ﾃーﾌﾞﾙﾘｾｯﾄ
	mov	    r9d, OFFSET FLAT:KT
	mov	    r10d, OFFSET FLAT:VT

# ｼﾓﾅｲｽﾞﾃーﾌﾞﾙから探す
.SHIMONIZE_C:
        # ﾃーﾌﾞﾙ終端まできたのでｽｷｯﾌﾟ
        mov	    rcx, QWORD PTR [r9]
        test	rcx, rcx
        je	    .SKIP_CHAR_L

        # 1ﾊﾞｲﾄ目がE3じゃなければｽｷｯﾌﾟ
        cmp	    BYTE PTR [rcx], 0xffffffe3
        jne	    .SHIMONIZE_NEXT

        # 2ﾊﾞｲﾄ目判定
        cmp	    r11b, BYTE PTR [rcx+1]
        jne	    .SHIMONIZE_NEXT

        # 3ﾊﾞｲﾄ目判定
        mov	    bl, BYTE PTR [rdi+2]
        cmp	    BYTE PTR [rcx+2], bl
        jne	    .SHIMONIZE_NEXT


        # 置き換えﾃーﾌﾞﾙﾛーﾄﾞ
        mov	    rcx, QWORD PTR [r10]

    # ｼﾓﾅｲｽﾞ:
    .SHIMONIZE_L:
        # 半角文字で置き換える
        mov	    r9b, BYTE PTR [rcx]
        test	r9b, r9b
        je	    .NEXT_CHAR
        inc	    eax
        mov	    BYTE PTR [rsi], r9b
        inc	    rsi

        # 限界値ﾁｪｯｸ
        lea	    r9d, [rax-1]
        cmp	    r9d, edx
        jge	    .BAILOUT # 限界超えてる

        # 次のﾊﾞｲﾄへ
        inc	    rcx
        jmp	    .SHIMONIZE_L

    .SHIMONIZE_NEXT:
        add	    r9, 8
        add	    r10, 8

        # 次
        jmp	    .SHIMONIZE_C

# 対象外文字なのでそのままｺﾋﾟー
.SKIP_CHAR:
	xor	    ecx, ecx
    .SKIP_CHAR_L:
        mov	    r9b, BYTE PTR [rdi+rcx]
        inc	    eax
        inc	    rsi
        mov	    BYTE PTR [rsi-1], r9b

        # 限界値ﾁｪｯｸ
        lea	    r9d, [rax-1]
        cmp	    edx, r9d
        jle	    .BAILOUT # 超えてるのでﾍﾞｲﾙｱｳﾄ
        inc	    rcx

        cmp	    r8d, ecx
        jg	    .SKIP_CHAR_L

.NEXT_CHAR:
	movsx	r8, r8d
	add	rdi, r8

    # 次
	jmp	.CVT_LOOP

.BAILOUT:
.END_CVT:
    # 変換後の長さ返す
	pop	rbx
	ret
