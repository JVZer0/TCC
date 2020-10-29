import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Excluir anuncio/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function ExcluirAnuncio(props){
    const navegacao = useHistory();

    const [infosUser, setInfosUser] = useState(props.location.state);
    const [meusanuncios, setMeusAnuncios] = useState([]);

    const deletarAnuncio = async () => {
        try{
            const resp = await api.deletarAnuncio(infosUser.item.idAnuncio, infosUser.item.idUsuario);
            console.log(infosUser)
            navegacao.goBack();
            toast.success("Anuncio deletado com sucesso")
        }
        catch (e){

        }
    }

    const consultarMeusAnuncios = async () => {
        try{
            const resp = await api.consultarAnuncioDetalhado(infosUser.item.idAnuncio);
            setMeusAnuncios(resp);
        }
        catch (e){

        }
    }

    useEffect(() => {
        consultarMeusAnuncios();
      }, []);

    return(
        <div className="nin">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infosUser.infos}} ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infosUser.infos}}>Fazer novas consultas</Link>
                </div>
                
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infosUser.infos}}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infosUser.infos }}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusFavoritos", state: infosUser.infos }}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>
            
            <div className="nan">
                <h4 className="nat">Tem certeza que deseja excluir o anuncio: <h5><b>{meusanuncios.titulo}</b></h5></h4> 
                <h4>publicado em <h5><b>{meusanuncios.publicacao}</b></h5></h4>

                <div className="sahaha">
                    <Link to={{ pathname: "/MeusAnuncios", state: infosUser.infos}}><button className="botoxo">Não</button></Link>
                    <button className="botoxo" onClick={deletarAnuncio}>Sim</button>
                </div>
            </div>
        </div>
    )
}