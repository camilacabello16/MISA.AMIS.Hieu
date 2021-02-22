<template>
    <div class="table-pagination">
        <div class="total-data">
            <p>Tổng số: <span>{{numberOfData}}</span> bản ghi</p>
        </div>
        <div class="wp-table-pagination">
            <div class="number-per-page">
                <select v-model="dataPerPage" @click="handleChangeOffset">
                    <option value="20" >20 bản ghi trên 1 trang</option>
                    <option value="50" >50 bản ghi trên 1 trang</option>
                    <option value="100" >100 bản ghi trên 1 trang</option>
                </select>
            </div>
            <div class="pagination-data">
                <!-- <div class="pre-page disable-button" @click="prePage">Trước</div> -->
                <div 
                    class="pre-page" 
                    :class="{'disable-button': activePage == 1}"
                    @click="prePage"
                >Trước</div>
                <div class="pagi-nub">
                    <div 
                        class="pagi-nub__item"
                        v-for="(page, index) in numberPages"
                        :key="index"
                        :class="{'page-active' : page == activePage}"
                        @click="handleChangePage"
                        :id="page"
                    >{{page}}</div>
                </div>
                <div 
                    class="pre-page" 
                    :class="{'disable-button': activePage == numberPages}"
                    @click="nextPage"
                >Sau</div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'EmployeeListPagination',
    data(){
        return{
            activePage: 1,
            dataPerPage: 20,
            numberOfData: 0
        }
    },
    props:{
        offset: String
    },
    methods: {
        // thay đổi trang
        handleChangePage:function(selectPage){
            selectPage = parseInt(event.currentTarget.id);
            this.activePage = selectPage;
            this.$emit('change-page', selectPage);
        },

        // chuyển về trang trước đó
        prePage:function(selectPage){
            if(this.activePage > 1){
                this.activePage -= 1;
            }
            selectPage = this.activePage;
            this.$emit('pre-page', selectPage);
        },

        // chuyển về trang sau 
        nextPage:function(selectPage){
            if(this.activePage < this.numberPages){
                this.activePage += 1;
            }
            selectPage = this.activePage;
            this.$emit('next-page', selectPage);
        },

        // thay đổi số lượng nhân viên mỗi trang
        handleChangeOffset:function(){
            this.activePage = 1;
            this.$emit('change-offset', this.dataPerPage);
        }
    },
    mounted(){
        axios.get('https://localhost:44344/api/v1/employee/number-data').then((response) => {
            this.numberOfData = response.data;
        })
        this.dataPerPage = this.offset;
    },
    computed: {
        numberPages(){
            return Math.ceil(this.numberOfData / this.dataPerPage)
        }
    }
}
</script>