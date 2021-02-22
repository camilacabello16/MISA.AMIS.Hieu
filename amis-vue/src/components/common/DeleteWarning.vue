<template>
    <div class="delete-warning">
        <div class="del-warn">
            <div class="del-warn__icon"></div>
            <div class="del-warn__txt">Bạn có thực sự muốn xóa Nhân viên này không?</div>
        </div>
        <div class="del-warn__btn">
            <div class="btn-form btn-cancel" @click="handleCancelDelete">Không</div>
            <div class="btn-form btn-add-form" @click="handleDoDelete">Có</div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'DeleteWarning',
    methods: {
        handleCancelDelete: function(){
            this.$emit('cancel-delete');
        },
        handleDoDelete: function(){
            this.$emit('do-delete');
        }
    }
}
</script>

<style scoped>

</style>