node {
        stage('SCM') {
            git 'https://github.com/shanthilakshmi/Test_JenkinsPipeline.git'
         }
    stage('clean') {
        sh label: '', script: 'dotnet clean'
    }
    stage('compile') {
        sh label: '', script: 'dotnet run'
    }
        stage( 'Nuget pack' ) {
         sh label: '', script: 'dotnet pack'
        }
        stage( 'publish' ){
          sh lable: '', script: 'dotnet publish'
       }
}
