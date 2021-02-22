<template>
    <div class="dialog-employee">
        <div class="wp-dialog-icon">
            <div class="dialog-help-icon"></div>
            <div class="dialog-help-close" @click="handleCloseDialog"></div>
        </div>
        <div class="dialog-header">
            <p class="dialog-header__txt">Thông tin nhân viên</p>
            <div class="check-info">
                <input type="checkbox" />
                <p>Là khách hàng</p>
            </div>
            <div class="check-info">
                <input type="checkbox" />
                <p>Là nhà cung cấp</p>
            </div>
        </div>
        <div class="dialog-body">
            <div class="body-top">
                <div class="body-top__left">
                    <div class="wp-inp-code-name">
                        <div class="inp inp-code">
                            <label>Mã <span class="require-blank">*</span></label>
                            <input 
                                v-show="isAdd == false" 
                                type="text" 
                                v-model="employeeInfo.EmployeeCode" 
                                id="EmployeeCode"
                            />
                            <input 
                                v-show="isAdd == true" 
                                type="text" 
                                :value="employeeCodeMax | IncreaseCode" 
                                ref="EmployeeCode"
                                id="EmployeeCodeAdd"
                            />
                        </div>
                        <div class="inp inp-name">
                            <label>Tên <span class="require-blank">*</span></label>
                            <input 
                                type="text" 
                                v-model="employeeInfo.FullName" 
                                @blur="$v.employeeInfo.FullName.$touch()"
                            />
                            <template v-if="$v.employeeInfo.FullName.$error">
                                <span class="error" v-if="!$v.employeeInfo.FullName.required">Vui lòng nhập họ và tên</span>
                            </template>
                        </div>
                    </div>
                    <div class="inp inp-department">
                        <label>Đơn vị <span class="require-blank">*</span></label>
                        <select v-model="employeeInfo.DepartmentId">
                            <option 
                                v-for="(department, index) in departments.data" 
                                :key="index"
                                :value="index + 1"
                            >{{department.DepartmentName}}</option>
                        </select>
                        <template v-if="$v.employeeInfo.DepartmentId.$error">
                            <span class="error" v-if="!$v.employeeInfo.DepartmentId.required">Vui lòng chọn phòng ban</span>
                        </template>
                    </div>
                    <div class="inp inp-position">
                        <label>Chức danh</label>
                        <input type="text" v-model="employeeInfo.EmployeeTitle" />
                    </div>
                </div>
                <div class="body-top__left">
                    <div class="wp-inp-birth-gender">
                        <div class="inp inp-birth">
                            <label>Ngày sinh</label>
                            <input 
                                type="date" 
                                v-model="employeeInfo.DateOfBirth" 
                                ref="DateOfBirth"
                            />
                        </div>
                        <div class="inp inp-gender">
                            <label>Giới tính</label>
                            <div class="gender">
                                <div class="gender-item">
                                    <input type="radio" name="gender" value="0" v-model="employeeInfo.Gender"/>
                                    <span>Nam</span>
                                </div>
                                <div class="gender-item">
                                    <input type="radio" name="gender" value="1" v-model="employeeInfo.Gender"/>
                                    <span>Nữ</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="wp-inp-id">
                        <div class="inp inp-id">
                            <label>Số CMND</label>
                            <input 
                                type="text" 
                                v-model="employeeInfo.IdentifyNumber" 
                                ref="IdentifyNumber" 
                            />
                        </div>
                        <div class="inp inp-realease-day">
                            <label>Ngày cấp</label>
                            <input 
                                type="date" 
                                v-model="employeeInfo.ReleaseDay" 
                                ref="ReleaseDay"
                            />
                        </div>
                    </div>
                    <div class="inp release-location">
                        <label>Nơi cấp</label>
                        <input type="text" v-model="employeeInfo.ReleaseLocation" />
                    </div>
                </div>
            </div>
            <div class="body-bottom">
                <div class="menu-dialog-tab">
                    <div 
                        class="menu-dialog-tab__item" 
                        @click="handleChooseAddress"  
                        :class="{'active-tab': isOpenAdress}"
                    >Liên hệ</div>
                    <div 
                        class="menu-dialog-tab__item" 
                        @click="handleChooseBankInfo" 
                        :class="{'active-tab': isOpenBankInfo}"
                    >Tài khoản ngân hàng</div>
                </div>
                <div class="body-bottom-form">
                    <div class="form-address" v-if="isOpenAdress">
                        <div class="inp inp-address">
                            <label>Địa chỉ</label>
                            <input type="text" v-model="employeeInfo.Address" />
                        </div>
                        <div class="wp-phone-email">
                            <div class="inp inp-phone">
                                <label>ĐT di động</label>
                                <input type="text" v-model="employeeInfo.PhoneNumber" />
                            </div>
                            <div class="inp inp-phone">
                                <label>ĐT cố định</label>
                                <input type="text" v-model="employeeInfo.FixPhoneNumber" />
                            </div>
                            <div class="inp inp-phone">
                                <label>Email</label>
                                <input type="text" v-model="employeeInfo.Email" />
                            </div>
                        </div>
                    </div>
                    <div class="form-bank-info" v-if="isOpenBankInfo" id="bankAccount">
                        <div class="bank-info" v-for="(numberOfAccount, index) in numberOfAccounts" :key="index">
                            <div class="bank-info-column">
                                <div class="bank-info__title">SỐ TÀI KHOẢN</div>
                                <div class="inp inp-bank">
                                    <input type="text" v-model="employeeInfo.BankNumber" />
                                </div>
                            </div>
                            <div class="bank-info-column">
                                <div class="bank-info__title">TÊN NGÂN HÀNG</div>
                                <div class="inp inp-bank">
                                    <input type="text" v-model="employeeInfo.BankName" />
                                </div>
                            </div>
                            <div class="bank-info-column">
                                <div class="bank-info__title">CHI NHÁNH</div>
                                <div class="inp inp-bank">
                                    <input type="text" v-model="employeeInfo.BankAddress" />
                                </div>
                            </div>
                            <div class="bank-info-column">
                                <div class="bank-info__title">TỈNH/TP CỦA NGÂN HÀNG</div>
                                <div class="inp inp-bank">
                                    <input type="text" v-model="employeeInfo.BankCity" />
                                </div>
                            </div>
                            <div class="bank-info-column-last">
                                <div class="bank-info__title"></div>
                                <div class="bank-info__icon"></div>
                            </div>
                        </div>
                        <div class="wp-btn-bank">
                            <div class="btn-bank" @click="addBankAccount">Thêm dòng</div>
                            <div class="btn-bank" @click="removeBankAccount">Xóa hết dòng</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="dialog-footer">
            <div class="wp-form-btn">
                <button type="button" class="btn-form btn-cancel" @click="handleCloseDialog">Hủy</button>
                <div class="wp-btn-save">
                    <button type="button" class="btn-form btn-save" @click="handleUpdateEmployee">Cất</button>
                    <button class="btn-form btn-add-form" type="button" @click="handleAddEmployee">Cất và thêm</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { required } from 'vuelidate/lib/validators';

export default {
    name: 'EmployeeListDetail',
    data(){
        return{
            isOpenAdress: true,
            isOpenBankInfo: false,
            employeeInfo: {},
            departments: [],
            employeeCodeMax: '',
            numberOfAccounts: 1,
            bankAccount: [],
            bankAccountInfo: {}
        }
    },
    validations: {
        employeeInfo: {
            FullName: {
                required
            },
            DepartmentId: {
                required
            }
        }
    },
    props:{
        employee: Object,
        isAdd: Boolean
    },
    methods: {
        // gửi sự kiện đóng form lên component cha
        handleCloseDialog: function(){
            this.$emit('close-dialog');
        },

        // chuyển sang tab liên hệ trong dialog
        handleChooseAddress:function(){
            this.isOpenAdress = true;
            this.isOpenBankInfo = false;
        },

        // chuyển sang tab thông tin ngân hàng trong dialog
        handleChooseBankInfo:function(){
            this.isOpenAdress = false;
            this.isOpenBankInfo = true;
        },

        // định dạng ngày tháng năm trong dialog
        formatDateForm:function(aaa) {
            var date = new Date(aaa);
            var day = date.getDate() > 9 ? date.getDate() : '0' + date.getDate();
            var month = date.getMonth() + 1 > 9 ? date.getMonth() + 1 : '0' + (date.getMonth() + 1);
            var year = date.getFullYear();
            return year + '-' + month + '-' + day;
        },

        // thêm mới hoặc cập nhật nhân viên
        handleAddEmployee:function(){
            // validate
                // validate sai thì hiện thông báo
                // validate đúng thì thực hiện thêm hoặc cập nhật
            this.$v.employeeInfo.$touch();
            if(this.$v.employeeInfo.$invalid) return;
            if(this.$refs.DateOfBirth.value == ''){
                this.employeeInfo.DateOfBirth = new Date(1,1,1);
            }
            if(this.$refs.ReleaseDay.value == ''){
                this.employeeInfo.ReleaseDay = new Date(1,1,1);
            }
            // thêm mới nhân viên
            if(this.isAdd == true){
                this.employeeInfo.EmployeeCode = this.$refs.EmployeeCode.value;
                if(this.$refs.IdentifyNumber.value == ''){
                    console.log(1);
                    this.employeeInfo.IdentifyNumber = '';
                }
                axios.post("https://localhost:44344/api/v1/employee", this.employeeInfo)
                    .then(response => {
                        console.log(response);
                        this.$emit('close-dialog');
                        this.$alert('Thêm thành công', '', 'success');
                    }).catch(e=>{
                        this.$alert(e.response.data.userMsg, '', 'error');
                    });
            // cập nhật nhân viên
            } else {
                axios.put("https://localhost:44344/api/v1/employee", this.employeeInfo)
                    .then(response => {
                        console.log(response);
                        this.$emit('close-dialog');
                        this.$alert('Cập nhật thành công', '', 'success');
                    }).catch(e=>{
                        this.$alert(e.response.data.userMsg, '', 'error');
                    });
            }
        },

        reloadData:function(){
            this.$emit('reload-component');
        },
        // cập nhật thông tin nhân viên
        handleUpdateEmployee:function(){
            if(this.isAdd == false){
                axios.put("https://localhost:44344/api/v1/employee", this.employeeInfo)
                    .then(response => {
                        console.log(response);
                        this.$emit('close-dialog');
                    this.$alert('Cập nhật thành công', '', 'success');
                    }).catch(e=>{
                        this.$alert(e.response.data.userMsg, '', 'error');
                    });
            }
        },

        addBankAccount:function(){
            this.numberOfAccounts += 1;
        },

        removeBankAccount:function(){
            this.numberOfAccounts = 0;
        }
    },
    mounted(){
        document.getElementById('EmployeeCode').focus();
        axios.get('https://localhost:44344/api/v1/Department').then((response) => {
            this.departments = response;
        })
        if(this.isAdd){
            document.getElementById('EmployeeCodeAdd').focus();
            axios.get('https://localhost:44344/api/v1/employee/employee-max-code').then((response) => {
                this.employeeCodeMax = response.data;
            })
        }
        this.employeeInfo = this.employee;
        this.employeeInfo.DateOfBirth = this.formatDateForm(this.employeeInfo.DateOfBirth);
        this.employeeInfo.ReleaseDay = this.formatDateForm(this.employeeInfo.ReleaseDay);
    },
    filters: {
        IncreaseCode:function(code){
            var res = code.substring(2, 8);
            var increaseCode = parseInt(res, 10) + 1;
            code = "NV" + increaseCode;
            return code;
        },
    }
}
</script>

<style scoped>
    .btn-form{
        cursor: pointer;
    }
    .menu-dialog-tab__item{
        cursor: pointer;
    }
    .active-tab{
        background-color: #C9E4FC;
    }
</style>