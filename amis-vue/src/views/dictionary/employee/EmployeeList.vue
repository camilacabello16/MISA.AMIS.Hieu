<template>
    <div>
        <div class="wp-content-table">
            <div class="content-title">
                <div class="content-title__left">
                    <p class="content-title__left--txt">Nhân viên</p>
                    <div class="wp-icon-back">
                        <div class="wp-icon-back__img"></div>
                        <div class="wp-icon-back__txt">Tất cả danh mục</div>
                    </div>
                </div>
                <div class="content-title__right">
                    <div 
                        class="btn-add"
                        @click="handleOpenDialog"
                    >Thêm</div>
                </div>
            </div>
            <div class="content-table">
                <div class="input-search">
                    <input 
                        type="text" 
                        placeholder="Tìm theo mã, tên nhân viên" 
                        v-model="searchText"
                    />
                    <div class="input-search__icon"></div>
                </div>
                <div class="table-employee">
                    <table class="table-employee-content">
                        <thead class="table-employee__header">
                            <tr>
                                <th>MÃ NHÂN VIÊN</th>
                                <th>TÊN NHÂN VIÊN</th>
                                <th>CHỨC DANH</th>
                                <th>TÊN ĐƠN VỊ</th>
                                <th>SỐ TÀI KHOẢN</th>
                                <th>TÊN NGÂN HÀNG</th>
                                <th>TRẠNG THÁI</th>
                                <th>CHI NHÁNH</th>
                                <th>CHỨC NĂNG</th>
                            </tr>
                        </thead>
                        <tbody class="table-employee__body">
                            <tr v-for="(employee, index) in employees.data" :key="index">
                                <td>{{employee.EmployeeCode}}</td>
                                <td class="name-employee">{{employee.FullName}}</td>
                                <td>{{employee.EmployeeTitle}}</td>
                                <td>{{employee.DepartmentName}}</td>
                                <td>{{employee.BankNumber}}</td>
                                <td>{{employee.BankName}}</td>
                                <td>Đang sử dụng</td>
                                <td class="bank-banch">{{employee.BankAddress}}</td>
                                <td class="edit-row">
                                    <p :id="'employee_'+index" @click="handleOpenEditEmployee">Sửa</p>
                                    <div class="edit-icon" @click="handleOpenDialogEdit" :id="index"></div>
                                    <div class="dialog-edit" :id="'dialog_' + index">
                                        <div class="dialog-edit__item">Nhân bản</div>
                                        <div 
                                            class="dialog-edit__item active-edit-row" 
                                            @click="handleOpenDeleteForm"
                                            :id="employee.EmployeeId"
                                        >Xóa</div>
                                        <div class="dialog-edit__item">Ngừng sử dụng</div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <EmployeeListPagination
                    :offset="offset"
                    @change-offset="handleChangeOffset"
                    @change-page="handleChangePage"
                    @pre-page="handlePrePage"
                    @next-page="handleNextPage"
                />
            </div>
        </div>
        <div class="wp-dialog-employee" v-if="isOpenDialog | isOpenDeleteForm"></div>
        <EmployeeListDetail 
            v-if="isOpenDialog" 
            @close-dialog="handleCloseDialog"
            @reload-component="handleReloadComponent"
            :employee="employeeInfo"
            :isAdd="isAdd"
        />
        <DeleteWarning 
            v-if="isOpenDeleteForm" 
            @cancel-delete="handleCancelDelete"
            @do-delete="handleDoDelete"
        />
    </div>
</template>

<script>
import EmployeeListDetail from './EmployeeListDetail';
import EmployeeListPagination from './EmployeeListPagination';
import DeleteWarning from '../../../components/common/DeleteWarning';
import axios from 'axios';

export default {
    name: 'EmployeeList',
    data(){
        return{
            isOpenDialog: false,
            isOpenDeleteForm: false,
            employees: [],
            employeeInfo: {},
            offset: "20",
            activePage: 1,
            idDelete: '',
            isAdd: false,
            searchText: '',
            itemDelete: null
        }
    },
    components: {
        EmployeeListDetail,
        EmployeeListPagination,
        DeleteWarning
    },
    methods: {
        // mở form thêm, cập nhật nhân viên
        handleOpenDialog: function(){
            this.isOpenDialog = true;
            this.isAdd = true;
            this.employeeInfo = {};
        },

        // đóng form thêm, cập nhật nhân viên
        handleCloseDialog: function(){
            this.isOpenDialog = false;
            this.employeeInfo = {};
        },

        // mở, đóng form edit
        handleOpenDialogEdit: function(){
            var id = event.currentTarget.id;
            var select = document.getElementById('dialog_'+id);
            this.itemDelete = select;
            select.classList.toggle('show-dialog');
            console.log(this.itemDelete)
        },

        // mở cảnh báo xóa
        handleOpenDeleteForm: function(){
            this.idDelete = event.currentTarget.id;
            this.isOpenDeleteForm = true;
        },

        // không thực hiện xóa
        handleCancelDelete: function(){
            this.isOpenDeleteForm = false;
            this.idDelete = '';
            this.itemDelete.classList.remove('show-dialog');
            this.itemDelete = null;
        },

        // mở menu các chức năng khác
        handleOpenEditEmployee: function(){
            var id = event.currentTarget.id;
            this.employeeInfo = this.employees.data[id.substring(9)];
            this.isOpenDialog = true;
            this.isAdd = false;
        },

        // thay đổi số lượng nhân viên hiển thị mỗi trang
        handleChangeOffset:function(dataPerPage){
            this.activePage = 1;
            this.offset = dataPerPage;
        },

        // chuyển sang trang khác
        handleChangePage: function(selectPage){
            this.activePage = selectPage;
        },

        // chuyển sang trang trước đó
        handlePrePage: function(selectPage){
            this.activePage = selectPage;
        },

        // chuyển sang trang sau
        handleNextPage: function(selectPage){
            this.activePage = selectPage;
        },

        // load lại bảng employee
        reloadEmployeeTable: function(activePage, offset){
            var pageUrl = (offset * (activePage-1));
            axios.get('https://localhost:44344/api/v1/employee-info/paging?positionstart=' + pageUrl + "&offset=" + this.offset)
                .then(response => (this.employees = response));
        },

        // thực hiện xóa nhân viên
        handleDoDelete:function(){
            axios.delete('https://localhost:44344/api/v1/employee/' + this.idDelete).then((response) => {
                console.log(response);
                this.reloadEmployeeTable(this.activePage, this.offset);
            });
            this.isOpenDeleteForm = false;
            this.itemDelete.classList.remove('show-dialog');
            this.itemDelete = null;
        },

        // load lại component
        handleReloadComponent:function(){
            this.reloadEmployeeTable(0, this.offset);
        },
    },
    mounted() {
        axios.get('https://localhost:44344/api/v1/employee-info/paging?positionstart=0&offset='+this.offset).then((response) => {
            this.employees = response;
        })
    },
    watch: {
        offset: {
            handler() {
                var pageUrl = (this.offset * (this.activePage-1));
                axios.get('https://localhost:44344/api/v1/employee-info/paging?positionstart=' + pageUrl + "&offset=" + this.offset)
                    .then(response => (this.employees = response));
            }
        },
        activePage: {
            handler() {
                this.reloadEmployeeTable(this.activePage, this.offset);
            }
        },
        searchText: {
            handler() {
                axios.get('https://localhost:44344/api/v1/employee-info/search?searchText=' + this.searchText)
                    .then(response => (this.employees = response));
                if(this.searchText === ""){
                    this.reloadEmployeeTable(this.activePage, this.offset);
                }
            }
        }
    },
}
</script>

<style scoped>
    .bank-banch{
        width: 250px;
    }
    .name-employee{
        width: 224px;
    }
</style>