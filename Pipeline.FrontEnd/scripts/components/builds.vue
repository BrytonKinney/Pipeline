<template>
    <div>
        <ul>
            <li v-for="build in activeBuilds" v-bind:key="build">
                {{ build.BuildName }}
            </li>
        </ul>
    </div>
</template>
<script lang="ts">
    import Vue from 'vue';
    export default Vue.extend({
        data: function () {
            return {
                activeBuilds: [
                    { BuildName: "None" },
                    { BuildName: "Build" }
                ]
            };
        }
    });
</script>